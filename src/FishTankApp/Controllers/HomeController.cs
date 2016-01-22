using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FishTankApp.ViewModels;
using FishTankApp.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FishTankApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IViewModelService viewModelService)
        {
            ViewModelService = viewModelService;
        }

        IViewModelService ViewModelService { get; }
        IUrlHelper UrlHelper { get; }

        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard.";
            return View(ViewModelService.GetDashboardViewModel());
        }

        public IActionResult Feed(int foodAmount)
        {
            var model = ViewModelService.GetDashboardViewModel();
            model.LastFed = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}. Amount: {foodAmount}";
            return View("Index", model);
        }
    }
}
