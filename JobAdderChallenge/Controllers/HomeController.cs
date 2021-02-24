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



            return View();
        }
    }
}