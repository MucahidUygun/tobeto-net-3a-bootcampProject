using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public class FileHelper
    {
        public static string Add(IFormFile file,string basePath) 
        {
            var result = newPath(file,basePath);
            var sourcePath = Path.GetTempFileName();

            using (var stream = new FileStream(sourcePath,FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Move(sourcePath, result.newPath);
            return result.path2;
        }
            private static (string newPath,string path2) newPath (IFormFile file , string basePath)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            var creatingFileName = Guid.NewGuid().ToString("N") + fileExtension;
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(),$@"wwwroot\Images\" + basePath + $@"\");
            if (Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var result = directoryPath + creatingFileName;

            return (result, $@"\Images\{basePath}\{creatingFileName}");

        }
    }
}
