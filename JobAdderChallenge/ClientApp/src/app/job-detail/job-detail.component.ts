import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { JobDetail } from '../interfaces/job';
import { JobAdderService } from '../services/job-adder.service';

@Component({
  selector: 'app-job-detail',
  templateUrl: './job-detail.component.html',
  styleUrls: ['./job-detail.component.scss']
})
export class JobDetailComponent implements OnInit {
  jobDetail: JobDetail;
  displayedColumns: string[] = ['name','skills'];
  isLoading: boolean = true;

  constructor(private route: ActivatedRoute, private jobAdderService: JobAdderService, private location: Location) { }

  ngOnInit(): void {
    this.getJob();
  }

  getJob(): void {
    this.isLoading = true;
    const id = +this.route.snapshot.paramMap.get('id');
    this.jobAdderService.getJobDetail(id).subscribe(jobDetail => {
      this.jobDetail = jobDetail;
      this.isLoading = false;
    });
  }

  formatCandidateSkills(jobSkills: string[], candidateSkills: string[]) {
    return candidateSkills.map(x => {
      let isDesiredSkill = jobSkills.indexOf(x) >= 0;
      return isDesiredSkill ? `<span><b>${x}</b></span>` : `<span>${x}</span>`;
    }).join('');
  }

  loadCandidate(id: number): void {
    // TODO: implement a candidate page which shows list of suitable jobs.
  }

  goBack(): void {
    this.location.back();
  }
}
