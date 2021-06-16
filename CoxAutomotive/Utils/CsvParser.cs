using System;
using System.Collections.Generic;
using System.Text;
using CoxAutomotive.Models;
using Microsoft.VisualBasic.FileIO;

namespace CoxAutomotive.Utils
{
    public static class CsvParser
    {
        public static IList<SalesRecord> Parse(string csvPath)
        {
            var header = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            const string delimeter = ","; //Delimeter is set to comma as this is a CSV
            var salesDetails = new List<SalesRecord>();
            var firstRow = true;

            using var parser = new TextFieldParser(csvPath, Encoding.UTF7) {TextFieldType = FieldType.Delimited};
            parser.SetDelimiters(delimeter);

            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();

                if (firstRow)
                {
                    for (var i = 0; i < fields.Length; i++)
                    {
                        header.TryAdd(fields[i], i);
                    }
                }
                else
                {
                    header.TryGetValue(nameof(SalesRecord.DealNumber), out var dealerNumberIndex);
                    header.TryGetValue(nameof(SalesRecord.CustomerName), out var customerNameIndex);
                    header.TryGetValue(nameof(SalesRecord.DealershipName), out var dealershipNameIndex);
                    header.TryGetValue(nameof(SalesRecord.Vehicle), out var vehicleIndex);
                    header.TryGetValue(nameof(SalesRecord.Price), out var priceIndex);
                    header.TryGetValue(nameof(SalesRecord.Date), out var dateIndex);

                    int.TryParse(fields[dealerNumberIndex], out var dealNumber);
                    decimal.TryParse(fields[priceIndex], out var price);
                    DateTime.TryParse(fields[dateIndex], out var date);
                    var salesDetailModel = new SalesRecord
                    {
                        DealNumber = dealNumber,
                        CustomerName = fields[customerNameIndex],
                        DealershipName = fields[dealershipNameIndex],
                        Vehicle = fields[vehicleIndex],
                        Price = price,
                        Date = date,
                    };
                    salesDetails.Add(salesDetailModel);
                }

                firstRow = false;
            }

            return salesDetails;
        }
    }
}