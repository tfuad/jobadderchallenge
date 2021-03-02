using JobAdderChallenge.Controllers.Api.Models;
using JobAdderChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobAdderChallenge.Controllers.Api
{
    public class JobAdderController : ApiController
    {
        JobAdderService service = new JobAdderService();
        IJobCandidateMatcherService matcherService = new JobCandidateMatcherService();

        [HttpGet]
        public async Task<IHttpActionResult> GetJobs()
        {
            var jobs = await service.GetJobsAsync();
            var candidates = await service.GetCandidatesAsync();

            var apiJobs = jobs
            .OrderBy(x => x.Company)
            .ThenBy(x => x.Name)
            .Select(x =>
            {
                var topCandidate = matcherService.GetJobCandidateScores(x, candidates).FirstOrDefault().Candidate;


                return new Job
                {
                    Id = x.JobId,
                    Name = x.Name,
                    Company = x.Company,
                    TopCandidate = new Candidate { Id = topCandidate.CandidateId, Name = topCandidate.Name }
                };
            });

            return Content(HttpStatusCode.OK, apiJobs);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetJobDetail(int id)
        {
            var job = (await service.GetJobsAsync()).FirstOrDefault(x => x.JobId == id);

            if (job == null)
            {
                return NotFound();
            }

            var candidates = await service.GetCandidatesAsync();

            // top candidate including 4 others
            var topCandidates = matcherService
                .GetJobCandidateScores(job, candidates)
                .Select(item => item.Candidate)
                .Take(5);

            var jobDetail = new JobDetail
            {
                Id = job.JobId,
                Name = job.Name,
                Company = job.Company,
                Skills = job.JobSkills,
                TopCandidates = topCandidates.Select(candidate => new TopCandidate
                {
                    Id = candidate.CandidateId,
                    Name = candidate.Name,
                    Skills = candidate.CandidateSkills
                }).ToArray()
            };

            return Content(HttpStatusCode.OK, jobDetail);
        }
    }
}
