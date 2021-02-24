using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Models
{
    public class Home
    {
        public List<Job> Jobs { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}