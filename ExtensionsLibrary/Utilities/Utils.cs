using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsLibrary.Utilities
{
    internal class Utils
    {
        public static DateTime GetDateFromString(string dateString)
        {
			try
			{
                CultureInfo provider = CultureInfo.InvariantCulture;
                string[] format = new string[] { "dd/MM/yyyy h:mm", "dd-MM-yyyy h:mm", "dd/MM/yyyy HH:mm", "dd/MM/yyyy", "dd-MM-yyyy HH:mm", "dd-MM-yyyy", "M/dd/yyyy hh:mm", "MM/dd/yyyy hh:mm", "MM/dd/yyyy hh:mm:ss", "d/MM/yyyy h:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt" };
                DateTime.TryParseExact(dateString, format, provider, DateTimeStyles.None, out DateTime date);
                return date;
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
