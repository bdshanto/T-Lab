using System;
using System.Collections.Generic;
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
    }
}
