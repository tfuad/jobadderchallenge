import { Component, OnInit } from '@angular/core';

import { Hero } from '../hero';
import { JobService } from '../job.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {
  heroes: Hero[] = [];

  constructor(private heroService: JobService, private messageService : MessageService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes(): void {
    this.heroService.getHeroes().subscribe(heroes => this.heroes = heroes);
  }
}
