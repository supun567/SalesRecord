using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoxAutomotive.Services;
using System.Collections.Generic;
using CoxAutomotive.Models;
using System;
using System.Globalization;

namespace CoxAutomotiveUnitTests
{
    [TestClass]
    public class SalesServiceTests
    {
        private readonly SalesService _salesService = new SalesService();

        [TestMethod]
        public void ValidateIList_IListNull_ShouldReturnFalse()
        {
            //Arrange
            IList<SalesRecord> salesDetails = new List<SalesRecord>
            {
                //Passing an empty object
            };

            //Act
            var result = _salesService.ValidateIList(salesDetails);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateIList_IListNotNull_ShouldReturnFalse()
        {
            //Arrange
            IList<SalesRecord> salesDetails = new List<SalesRecord>
            {
                new SalesRecord
                {
                    DealNumber = 123,
                    CustomerName="Mark Jameson",
                    DealershipName="Toyota Mississauga",
                    Vehicle="Toyota RAV4",
                    Price=23000,
                    Date=new DateTime(2020,05,09)
                    
                }
            }; 
            
            //Act
            var result = _salesService.ValidateIList(salesDetails);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
