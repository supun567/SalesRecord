using System;
using Microsoft.AspNetCore.Mvc;
using CoxAutomotive.Models;
using CoxAutomotive.Services;
using CoxAutomotive.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CoxAutomotive.Controllers
{
    public class ParserController : Controller
    {
        private readonly ISalesService _salesService;
        private readonly ILogger<ParserController> _logger;

        public ParserController(ISalesService salesService, ILogger<ParserController> logger)
        {
            _salesService = salesService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Starting file parsing");

            var path = HttpContext.Session.GetString("path");

            try
            {
                var salesDetails = CsvParser.Parse(path);
                
                var bestSellingVehicle = _salesService.GetBestSellingVehicle(salesDetails);
                
                var salesMilestones = new SalesMilestones {BestSellingVehicle = bestSellingVehicle};
                var parserResult = new SalesDetails
                {
                    SalesRecords = salesDetails,
                    SalesMilestones = salesMilestones
                };
                return View(parserResult);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occured", e);
                throw;
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}