using FishTankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTankApp.Services
{
    public interface ISensorDataService
    {
        IntHistory GetWaterTemperatureFahrenheight();
        IEnumerable<IntHistory> GetWaterTemperatureFahrenheightHistory();
        IntHistory GetFishMotionPercentage();
        IEnumerable<IntHistory> GetFishMotionPercentageHistory();
        IntHistory GetWaterOpacityPercentage();
        IEnumerable<IntHistory> GetWaterOpacityPercentageHistory();
        IntHistory GetLightIntensityLumens();
        IEnumerable<IntHistory> GetLightIntensityLumensHistory();
    }
}
