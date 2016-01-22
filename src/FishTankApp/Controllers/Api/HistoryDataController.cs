using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FishTankApp.Services;
using FishTankApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FishTankApp.Controllers.Api
{
    public class HistoryDataController : Controller
    {
        public HistoryDataController(ISensorDataService sensorDataService)
        {
            SensorDataService = sensorDataService;
        }

        ISensorDataService SensorDataService { get; }

        public IEnumerable<IntHistory> WaterTemperatureHistory()
        {
            return SensorDataService.GetWaterTemperatureFahrenheightHistory();
        }

        public IEnumerable<IntHistory> FishMotionPercentageHistory()
        {
            return SensorDataService.GetFishMotionPercentageHistory();
        }

        public IEnumerable<IntHistory> WaterOpacityPercentageHistory()
        {
            return SensorDataService.GetWaterOpacityPercentageHistory();
        }

        public IEnumerable<IntHistory> LightIntensityLumensHistory()
        {
            return SensorDataService.GetLightIntensityLumensHistory();
        }
    }
}
