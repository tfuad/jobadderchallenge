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
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}