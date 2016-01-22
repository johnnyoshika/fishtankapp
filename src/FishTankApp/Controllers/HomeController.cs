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
        public HomeController(ISensorDataService sensorDataService, IUrlHelper urlHelper)
        {
            SensorDataService = sensorDataService;
            UrlHelper = urlHelper;
        }

        ISensorDataService SensorDataService { get; }
        IUrlHelper UrlHelper { get; }

        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard.";
            return View(new DashboardViewModel
            {
                WaterTemperatureTile = new SensorTileViewModel
                {
                    Title = "Water Temperature",
                    Value = SensorDataService.GetWaterTemperatureFahrenheight().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = UrlHelper.Action("GetWaterTemperatureChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish Motion",
                    Value = SensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-car",
                    Url = UrlHelper.Action("GetFishMotionPercentageChart", "History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water Opacity",
                    Value = SensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-adjust",
                    Url = UrlHelper.Action("GetWaterOpacityPercentageChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light Intensity",
                    Value = SensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-lightbulb-o",
                    Url = Url.Action("GetLightIntensityLumensChart", "History")
                }
            });
        }
    }
}
