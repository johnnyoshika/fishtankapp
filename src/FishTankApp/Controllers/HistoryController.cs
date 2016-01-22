using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FishTankApp.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FishTankApp.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult WaterTemperatureChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water Temperature",
                DataUrl = Url.Action("WaterTemperatureHistory", "HistoryData")
            });
        }

        public IActionResult FishMotionPercentageChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Fish Motion Percentage",
                DataUrl = Url.Action("FishMotionPercentageHistory", "HistoryData")
            });
        }

        public IActionResult WaterOpacityPercentageChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Water Opacity Percentage",
                DataUrl = Url.Action("WaterOpacityPercentageHistory", "HistoryData")
            });
        }

        public IActionResult LightIntensityLumensChart()
        {
            return View("Chart", new ChartViewModel
            {
                Title = "Light Intensity",
                DataUrl = Url.Action("LightIntensityLumensHistory", "HistoryData")
            });
        }
    }
}
