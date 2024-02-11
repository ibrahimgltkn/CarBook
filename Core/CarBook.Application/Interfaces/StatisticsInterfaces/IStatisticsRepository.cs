using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPrizeForDaily();
        decimal GetAvgRentPrizeForWeekly();
        decimal GetAvgRentPrizeForMonthly();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaxComment();
        int GetCarCountBySmallerThan1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();

    }
}
