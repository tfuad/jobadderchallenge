using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderChallenge.Services.Models
{
    public class Job
    {
        [JsonProperty("jobId")]
        public int JobId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("skills")]
        public string Skills { get; set; }
    }
}