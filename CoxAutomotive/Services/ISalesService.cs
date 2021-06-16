using System.Collections.Generic;
using CoxAutomotive.Models;

namespace CoxAutomotive.Services
{
    public interface ISalesService
    {
        (string vehicleName, int totalSales) GetBestSellingVehicle(IList<SalesRecord> salesDetails);

        bool ValidateIList(IList<SalesRecord> salesDetails);
    }
}