using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoxAutomotive.Services
{
    public interface IFileService
    {
        Task UploadFile(IFormFile csvFile, string csvPath);

        bool UploadSuccess(string csvPath);

        bool ValidateFile(IFormFile csvFile);
    }
}