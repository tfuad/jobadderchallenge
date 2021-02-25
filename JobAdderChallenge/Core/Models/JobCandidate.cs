using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Core.Models
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
    }
}