using EdicoesEmMassa.Model;
using EdicoesEmMassa.Repository;
using EdicoesEmMassa.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EdicoesEmMassa.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _DashboardService;


        public DashboardController(IDashboardService dashboardService)
        {
            _DashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View(_DashboardService.GetDataForDashboard());
        }
    }
}
