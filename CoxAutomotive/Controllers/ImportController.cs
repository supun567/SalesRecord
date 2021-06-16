using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CoxAutomotive.Models;
using CoxAutomotive.Services;
using Microsoft.Extensions.Logging;

namespace CoxAutomotive.Controllers
{
    public class ImportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly ILogger<ImportController> _logger;

        public ImportController(IWebHostEnvironment webHostEnvironment, IFileService fileService,
            ILogger<ImportController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _logger = logger;
        }

        // GET: ImportController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile csvFile)
        {
            try
            {
                _logger.LogInformation("Starting file import");
                var csvPath = Path.Combine(_webHostEnvironment.WebRootPath, "csv", csvFile.FileName);

                await _fileService.UploadFile(csvFile, csvPath);

                var uploadStatus = _fileService.UploadSuccess(csvPath);

                if (uploadStatus)
                {
                    //Writing path to session
                    HttpContext.Session.SetString("path", csvPath);

                    return RedirectToAction("Index", "Parser");
                }
                else
                    return RedirectToAction("Error", "Parser");

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured", ex);
                ViewData["Message"] = ex.Message;
                throw;
            }
        }
    }
}