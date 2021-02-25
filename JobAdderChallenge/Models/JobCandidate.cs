using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Models
{
    public class JobCandidate
    {
        public Job Job { get; set; }

        public Candidate Candidate { get; set; }

        public double Score { get; set; }

        public JobCandidate(Job job, Candidate candidate, double score)
        {
            Job = job;
            Candidate = candidate;
            Score = score;
        }

        public JobCandidate(Core.Models.JobCandidate item)
        {
            Job = new Job(item.Job);
            Candidate = new Candidate(item.Candidate);
            Score = item.Score;
        }
    }
}