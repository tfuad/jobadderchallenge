using JobAdderChallenge.Core.Models;
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

        public async Task<List<Job>> GetJobsAsync() => await GetAsync<List<Job>>("jobs");
        public async Task<List<Candidate>> GetCandidatesAsync() => await GetAsync<List<Candidate>>("candidates");

        private async Task<T> GetAsync<T>(string requestUri)
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var content = await httpClient.GetStringAsync(requestUri);
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}