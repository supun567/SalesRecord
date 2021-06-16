using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoxAutomotive.Models
{
    public class SalesRecord
    {
        [DisplayName("Deal Number")] public int DealNumber { get; set; }

        [DisplayName("Customer Name")] public string CustomerName { get; set; }

        [DisplayName("Dealership Name")] public string DealershipName { get; set; }

        public string Vehicle { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "CAD{0:C2}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}