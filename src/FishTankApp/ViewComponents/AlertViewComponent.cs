using FishTankApp.Options;
using FishTankApp.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTankApp.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {
        public AlertViewComponent(ISensorDataService sensorDataService, IOptions<ThresholdOptions> thresholdConfig)
        {
            SensorDataService = sensorDataService;
            ThresholdOptions = thresholdConfig.Value;
        }

        ISensorDataService SensorDataService { get; }
        ThresholdOptions ThresholdOptions { get; }

        public IViewComponentResult Invoke()
        {
            var messages = new List<string>();

            if (SensorDataService.GetFishMotionPercentage().Value > ThresholdOptions.FishMotionMax)
                messages.Add("Too much fish activity.");
            if (SensorDataService.GetFishMotionPercentage().Value < ThresholdOptions.FishMotionMin)
                messages.Add("Hmmm, so dead fish.");

            if (SensorDataService.GetLightIntensityLumens().Value > ThresholdOptions.LightIntesityMax)
                messages.Add("Too much light!");
            if (SensorDataService.GetLightIntensityLumens().Value < ThresholdOptions.LightIntensityMin)
                messages.Add("Too dark!");

            if (SensorDataService.GetWaterOpacityPercentage().Value > ThresholdOptions.WaterOpacityMax)
                messages.Add("Fish can't see you!");
            if (SensorDataService.GetWaterOpacityPercentage().Value < ThresholdOptions.WaterOpacityMin)
                messages.Add("Water is too clean.");

            if (SensorDataService.GetWaterTemperatureFahrenheight().Value > ThresholdOptions.WaterTemperatureMax)
                messages.Add("Water too hot!");
            if (SensorDataService.GetWaterTemperatureFahrenheight().Value < ThresholdOptions.WaterTemperatureMin)
                messages.Add("Water too cold!");

            return View(messages);
        }
    }
}
