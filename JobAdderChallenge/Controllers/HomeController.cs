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
            var jobs = await service.GetJobsAsync();
            var candidates = await service.GetCandidatesAsync();

            var model = new Home();

            model.Jobs = jobs.Select(x => new Job(x)).ToList();
            model.Candidates = candidates.Select(x => new Candidate(x)).ToList();

            return View(model);
        }
    }
}