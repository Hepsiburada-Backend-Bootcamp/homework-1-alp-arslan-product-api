using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public static class Extensions
    {
        public static List<T> SortBy<T>(this List<T> source, string sortParameter)
        {

            if (source == null || sortParameter == null)
                throw new ArgumentNullException();

            sortParameter = char.ToUpper(sortParameter[0]) + sortParameter[1..].ToLower();
            //source = source.OrderBy(s => s. sortParameter);
            source = (from item in source
                     orderby sortParameter
                     select item).ToList();

            return source;
        }
    }
}
