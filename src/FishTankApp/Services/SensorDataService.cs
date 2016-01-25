using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTankApp.Models;

namespace FishTankApp.Services
{
    public class SensorDataService : ISensorDataService
    {
        IEnumerable<IntHistory> _waterTemperatureHistory;
        IEnumerable<IntHistory> _fishMotionHistory;
        IEnumerable<IntHistory> _waterOpacityHistory;
        IEnumerable<IntHistory> _lightOpacityHistory;

        public IntHistory GetWaterTemperatureFahrenheight()
        {
            return GetWaterTemperatureFahrenheightHistory().Last();
        }

        public IEnumerable<IntHistory> GetWaterTemperatureFahrenheightHistory()
        {
            return _waterTemperatureHistory ?? (_waterTemperatureHistory = GetHistory(70, 90));
        }

        public IntHistory GetFishMotionPercentage()
        {
            return GetFishMotionPercentageHistory().Last();
        }

        public IEnumerable<IntHistory> GetFishMotionPercentageHistory()
        {
            return _fishMotionHistory ?? (_fishMotionHistory = GetHistory(0, 100));
        }

        public IntHistory GetWaterOpacityPercentage()
        {
            return GetWaterOpacityPercentageHistory().Last();
        }

        public IEnumerable<IntHistory> GetWaterOpacityPercentageHistory()
        {
            return _waterOpacityHistory ?? (_waterOpacityHistory = GetHistory(0, 100));
        }

        public IntHistory GetLightIntensityLumens()
        {
            return GetLightIntensityLumensHistory().Last();
        }

        public IEnumerable<IntHistory> GetLightIntensityLumensHistory()
        {
            return _lightOpacityHistory ?? (_lightOpacityHistory = GetHistory(0, 5000));
        }

        IEnumerable<IntHistory> GetHistory(int min, int max)
        {
            var random = new Random();
            var result = new List<IntHistory>();
            for (int i = -10; i < 1; i++)
                result.Add(new IntHistory(DateTime.Now.AddHours(i), random.Next(min, max)));

            return result;
        }
    }
}
