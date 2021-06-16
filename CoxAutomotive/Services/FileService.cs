using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoxAutomotive.Services
{
    public class FileService : IFileService
    {
        public async Task UploadFile(IFormFile csvFile, string csvPath)
        {
            try
            {
                var fileValidated = ValidateFile(csvFile);

                              
                if (!fileValidated) throw new Exception("File not available or file type not valid; Only CSV files are allowed");

                await using var uploadCsv = new FileStream(csvPath, FileMode.Create);

                await csvFile.CopyToAsync(uploadCsv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UploadSuccess(string csvPath)
        {
            if (String.IsNullOrEmpty(csvPath))
            {
                return false;
            }
            else
                return true;
        }

        public bool ValidateFile(IFormFile csvFile)
        {
            if ((csvFile != null) && (Path.GetExtension(csvFile.FileName)==".csv"))
                return true;
            else 
                return false;
        }
    }
}