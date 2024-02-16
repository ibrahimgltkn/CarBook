using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 3).ToList();
            return values;
        }

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
			throw new NotImplementedException();
		}

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From " +
					"(Select Brands.Name +' - '+ model as Marka_Model,CoverImageUrl, PricingID,Amount From CarPricings " +
                    "Inner Join Cars On Cars.CarID = CarPricings.CarID " +
                    "Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable " +
                    "Pivot (Sum(Amount) For PricingID In ([3],[4],[5])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel viewModel = new CarPricingViewModel()
                        {
                            Model = reader["Marka_Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader[2]),
                                Convert.ToDecimal(reader[3]),
                                Convert.ToDecimal(reader[4])
                            }
                        };
                        values.Add(viewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}
