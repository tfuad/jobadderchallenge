import { Router } from '@angular/router';

import { Component, OnInit } from '@angular/core';

import { Job } from '../interfaces/job';

import { JobAdderService } from '../services/job-adder.service';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {
  jobs: Job[] = [];
  displayedColumns: string[] = ['id', 'company', 'name', 'topCandidate.name'];

  constructor(private router: Router, private jobService: JobAdderService, private messageService : MessageService) { }

  ngOnInit(): void {
    this.getJobs();
  }

  getJobs(): void {
    this.jobService.getJobs().subscribe(jobs => {
      this.jobs = jobs;
    });
  }

  loadJob(row): void {
    this.router.navigate([`/jobDetail/${row.id}`]);
  }
}
