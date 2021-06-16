using System.Collections.Generic;

namespace CoxAutomotive.Models
{
    public class SalesDetails
    {
        public IEnumerable<SalesRecord> SalesRecords { get; set; }
        public SalesMilestones SalesMilestones { get; set; }
    }
}