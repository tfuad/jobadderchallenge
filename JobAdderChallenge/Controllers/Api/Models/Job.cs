using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Controllers.Api.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public Candidate TopCandidate { get; set; }
    }
}