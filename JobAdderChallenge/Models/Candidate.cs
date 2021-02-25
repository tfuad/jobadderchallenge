using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string[] Skills { get; set; }

        public Candidate(Core.Models.Candidate candidate)
        {
            this.CandidateId = candidate.CandidateId;
            this.Name = candidate.Name;
            this.Skills = candidate.CandidateSkills;
        }
    }
}
