using System;
using System.Collections.Generic;
using System.Linq;
using CoxAutomotive.Models;

namespace CoxAutomotive.Services
{
    public class SalesService : ISalesService
    {
        public (string vehicleName, int totalSales) GetBestSellingVehicle(IList<SalesRecord> salesDetails)
        {
            var validateList = ValidateIList(salesDetails);

            if(!validateList)
                return (string.Empty, 0);

            var vehicles = salesDetails.Select(s => s.Vehicle);
            var groupedVehicles = vehicles?
                .GroupBy(g => g)
                .Select(x => new { Name = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count);

            var bestSellingVehicle = groupedVehicles.First();
            return (bestSellingVehicle.Name, bestSellingVehicle.Count);
        }

        public bool ValidateIList(IList<SalesRecord> salesDetails)
        {
            //Check whether salesDetails are received
            if (!salesDetails.Any())
            {
                return false;
            }
            else
                return true;
        }
    }
}