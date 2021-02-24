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

        public Job(Services.Models.Job job)
        {
            this.JobId = job.JobId;
            this.Name = job.Name;
            this.Company = job.Company;

            this.Skills = (job.Skills ?? "")
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .GroupBy(x => x)
                .FirstOrDefault()
                .ToArray();
        }
    }
}