import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';


import { Job, JobDetail } from '../interfaces/job';
import { Candidate, CandidateDetail } from '../interfaces/candidate';
import { JobCandidate } from '../interfaces/job-candidate';


import { HEROES } from '../mock-heroes';
import { MessageService } from './message.service';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JobAdderService {
  private jobUrl = 'api/JobAdder/GetJobs';
  private jobDetaileUrl = 'api/JobAdder/GetJobDetail';
  private candidateUrl = 'api/JobAdder/xxx';
  private candidateDetailUrl = 'api/JobAdder/xxx';

  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.jobUrl)
      .pipe(
        tap(_ => this.log('fetched jobs')),
        catchError(this.handleError<Job[]>('getJobs', []))
      )
  }

  getJobDetail(id: number): Observable<JobDetail> {
    const url = `${this.jobDetaileUrl}/${id}`;
    return this.http.get<JobDetail>(url)
      .pipe(
        tap(_ => this.log('fetched jobDetail')),
        catchError(this.handleError<JobDetail>('getJobDetail'))
      )
  }

  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(this.candidateUrl)
      .pipe(
        tap(_ => this.log('fetched candidates')),
        catchError(this.handleError<Candidate[]>('getJobs', []))
      )
  }

  getCandidateDetail(id: number): Observable<CandidateDetail> {
    const url = `${this.candidateDetailUrl}/${id}`;
    return this.http.get<CandidateDetail>(url)
      .pipe(
        tap(_ => this.log('fetched candidateDetail')),
        catchError(this.handleError<CandidateDetail>('getCandidateDetail'))
      )
  }

  private log(message: String): void {
    this.messageService.add(`JobService: ${message}`);
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  constructor(private http: HttpClient, private messageService: MessageService) { }
}
