using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Core.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Skills { get; set; }

        private string[] _jobSkills = null;
        public string[] JobSkills
        {
            get
            {
                return _jobSkills ?? (_jobSkills = GetSkills());
            }
        }

        private string[] GetSkills()
        {
            return (Skills ?? "")
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Distinct()
                .ToArray();
        }
    }
}