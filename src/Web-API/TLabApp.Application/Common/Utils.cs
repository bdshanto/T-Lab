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

            var filePath = Path.Combine(DateTime.Now.ToString("u") + file.FileName);
            return filePath.RemoveSpecialCharacters();
        }
        public static string RemoveSpecialCharacters(this string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                    sb.Append(c);
            return sb.ToString();
        }

    }
}
