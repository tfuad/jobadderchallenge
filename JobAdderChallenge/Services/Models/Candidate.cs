using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Services.Models
{
    public class Candidate
    {
        [JsonProperty("candidateId")]
        public int CandidateId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("skillTags")]
        public string SkillTags { get; set; }
    }
}