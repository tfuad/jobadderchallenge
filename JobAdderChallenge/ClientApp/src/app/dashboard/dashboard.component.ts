import { Component, OnInit } from '@angular/core';

import { Job } from '../interfaces/job';
import { JobAdderService } from '../services/job-adder.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  jobs: Job[] = [];

  constructor(private jobAdderService: JobAdderService) { }

  ngOnInit(): void {
    this.getJobs();
  }

  getJobs(): void {
    //this.jobAdderService.getJobs().subscribe(jobs => this.jobs = jobs);
  }

}
