using Microsoft.AspNet.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AspNetVNext.ServiceDashboard
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


