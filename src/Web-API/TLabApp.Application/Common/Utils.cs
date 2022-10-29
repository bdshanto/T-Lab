using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabApp.Application.Common
{
    public static class Utils
    {
        public static string CommaSeparateString(this IEnumerable<string> enumerable)
        {
            var enumerable1 = enumerable as string[] ?? enumerable.ToArray();
            if (!enumerable1.Any()) return string.Empty;

            var result = enumerable1.Aggregate((c, u) => c + ", " + u);
            return result;
        }
        public static string GenerateLocalUploadPath(IFormFile file)
        {
            var folderName = Path.Combine("wwwroot", "Files");
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            var uniqueFileName = DateTime.Now.ToString(CultureInfo.InvariantCulture) + file.FileName;
            var filePath = Path.Combine(folderName, uniqueFileName);
            return uniqueFileName;
        }
    }
}
