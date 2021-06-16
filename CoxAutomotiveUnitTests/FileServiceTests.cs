using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoxAutomotive.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace CoxAutomotiveUnitTests
{
    [TestClass]
    public class FileServiceTests
    {
        private readonly FileService _fileService = new FileService();

        [DataTestMethod]
        [DataRow((string)null)]
        public void UploadSuccess_PathIsNull_ShouldReturnFalse(string csvPath)
        {
            //Arrange

            //Act
            var result = _fileService.UploadSuccess(csvPath);

            //Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow("file_path_goes_here")]
        [DataRow("This_is_another_path")]
        public void UploadSuccess_PathIsNotNull_ShouldReturnTrue(string csvPath)
        {
            //Arrange

            //Act
            var result = _fileService.UploadSuccess(csvPath);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        
        public void ValidateFile_IFormFileIsNull_ShouldReturnFalse()
        {
            //Arrange
            IFormFile csvFile;
            csvFile = null;

            //Act
            var result = _fileService.ValidateFile(csvFile);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]

        public void ValidateFile_IFormFileNotNullExtensionCSV_ShouldReturnTrue()
        {
            //Arrange
            IFormFile csvFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file which is a CSV")), 0, 0, "Data", "Test.csv");
  
            //Act
            var result = _fileService.ValidateFile(csvFile);

            //Assert
            Assert.IsTrue(result);

        }


        [DataTestMethod]
        [DataRow("testFile.txt")]
        [DataRow("testFile.exe")]
        [DataRow("testFile.jpg")]
        [DataRow("testFile.png")]
        [DataRow("testFile.xlsx")]

        public void ValidateFile_IFormFileNotNullExtensionNotCSV_ShouldReturnFalse(string fileName)
        {
            //Arrange
            IFormFile csvFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file which is not a CSV")), 0, 0, "Data", fileName);

            //Act
            var result = _fileService.ValidateFile(csvFile);

            //Assert
            

            Assert.AreNotEqual(true,result);

        }

    }
}
