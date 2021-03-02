using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Controllers.Api.Models
{
    public class TopCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Skills { get; set; }
    }
}