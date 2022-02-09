using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pita.Infrastructure.Services.Dashboard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pita.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDashboardServices _dashboardServices;

        public HomeController(IDashboardServices dashboardServices)
        {
            _dashboardServices = dashboardServices;
        }
        public async Task<IActionResult> Index()
        {
           
            var data = await _dashboardServices.GetData();
            return View(data);
        }

        

       
    }
}
