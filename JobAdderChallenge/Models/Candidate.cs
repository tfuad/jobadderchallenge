using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Models
{
    public class Candidate
    {
            public int JobId { get; set; }
            public string Name { get; set; }
            public string[] Skills { get; set; }

            public Candidate(Services.Models.Candidate candidate)
            {
                this.JobId = candidate.CandidateId;
                this.Name = candidate.Name;

                this.Skills = (candidate.SkillTags ?? "")
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .GroupBy(x=>x)
                    .FirstOrDefault()
                    .ToArray();
            }
    }
}
