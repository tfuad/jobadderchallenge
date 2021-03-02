using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Core.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string SkillTags { get; set; }

        private string[] _candidateSkills = null;
        public string[] CandidateSkills
        {
            get
            {
                return _candidateSkills ?? (_candidateSkills = GetSkills());
            }
        }

        private string[] GetSkills()
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;
            return (SkillTags ?? "")
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(x => textInfo.ToTitleCase(x))
                .Distinct()
                .ToArray();
        }
    }
}