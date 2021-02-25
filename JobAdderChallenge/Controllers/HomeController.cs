using JobAdderChallenge.Models;
using JobAdderChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobAdderChallenge.Controllers
{
    public class HomeController : Controller
    {
        JobAdderService service = new JobAdderService();

        public async Task<ActionResult> Index()
        {
            IJobCandidateMatcherService matcher = new JobCandidateMatcherService();

            // able to swap out matcher methods
            // TODO: allow providing multiple matchers either through score aggregation or by sorting based on score from each matcher
            // matcher.SetMatcherMethod(new SkillStrengthMatcher());

            // Ideally we would only fetch a small collection of records if the api supports it
            // otherwise we could use a separate data ingestion process to store this information locally and serve it from our database.
            var jobs = await service.GetJobsAsync();
            var candidates = await service.GetCandidatesAsync();

            var model = new Home();
            foreach(var job in jobs)
            {
                var jobModel = new Job(job);

                var jobCandidates = matcher.GetJobCandidateScores(job, candidates)
                    .OrderByDescending(x => x.Score)
                    .Take(10)
                    .Select(x=> new JobCandidate(x))
                    .ToList();

                jobModel.JobCandidates.AddRange(jobCandidates);
                model.Jobs.Add(jobModel);
            }

            return View(model);
        }
    }
}