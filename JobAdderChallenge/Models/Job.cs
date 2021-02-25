using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string[] Skills { get; set; }

        public List<JobCandidate> JobCandidates { get; set; }

        public Job(Core.Models.Job job)
        {
            this.JobId = job.JobId;
            this.Name = job.Name;
            this.Company = job.Company;
            this.Skills = job.JobSkills;
            this.JobCandidates = new List<JobCandidate>();
        }
    }
}