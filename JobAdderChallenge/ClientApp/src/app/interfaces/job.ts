import { Candidate, TopCandidate } from './candidate';

export interface Job {
  id: number,
  name: string,
  company: string,
  topCandidate: Candidate
}

export interface JobDetail {
  id: number,
  name: string,
  company: string,
  skills: string[],
  topCandidates: TopCandidate[]
}



