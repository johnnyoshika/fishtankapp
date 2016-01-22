using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.ViewModels;
using Microsoft.AspNet.Mvc;

namespace FishTankApp.Services
{
    public class ViewModelService : IViewModelService
    {
        public ViewModelService(ISensorDataService sensorDataService, IUrlHelper urlHelper)
        {
            SensorDataService = sensorDataService;
            UrlHelper = urlHelper;
        }

        ISensorDataService SensorDataService { get; }
        IUrlHelper UrlHelper { get; }

        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                WaterTemperatureTile = new SensorTileViewModel
                {
                    Title = "Water Temperature",
                    Value = SensorDataService.GetWaterTemperatureFahrenheight().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = UrlHelper.Action("WaterTemperatureChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish Motion",
                    Value = SensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-car",
                    Url = UrlHelper.Action("FishMotionPercentageChart", "History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water Opacity",
                    Value = SensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-adjust",
                    Url = UrlHelper.Action("WaterOpacityPercentageChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light Intensity",
                    Value = SensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-lightbulb-o",
                    Url = UrlHelper.Action("LightIntensityLumensChart", "History")
                }
            };
        }
    }
}
