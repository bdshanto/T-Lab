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
        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }

    }
}
