using JobAdderChallenge.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace JobAdderChallenge.Services
{
    public class JobAdderService
    {
        readonly Uri baseAddress = new Uri("https://private-anon-151cea16d6-jobadder1.apiary-mock.com/");

        public string JobsJson
        {
            get
            {
                var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
                return File.ReadAllText($"{baseDirectory}\\jobs.json");
            }
        }

        public string CandidatesJson
        {
            get
            {
                var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
                return File.ReadAllText($"{baseDirectory}\\candidates.json");
            }
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var content = JobsJson; // await httpClient.GetStringAsync("jobs");
                return JsonConvert.DeserializeObject<List<Job>>(content);
            }
        }

        public async Task<List<Candidate>> GetCandidatesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var content = CandidatesJson;// await httpClient.GetStringAsync("candidates");
                return JsonConvert.DeserializeObject<List<Candidate>>(content);
            }
        }
    }
}