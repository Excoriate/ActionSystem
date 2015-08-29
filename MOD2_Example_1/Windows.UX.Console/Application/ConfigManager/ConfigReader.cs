using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.UX.Console.Application.ConfigManager
{
    internal class ConfigReader
    {
        public string GetNameFromConfigFile()
        {
            //var name = string.Empty;

            //AT: Lectura de archivo de configuracion.
            return   ConfigurationSettings.AppSettings["name"].
                ToString(CultureInfo.InvariantCulture);

            //return name;
        }









    }
}
