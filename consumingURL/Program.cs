using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;

namespace consumingURL
{
    class Program
    {
        public static string RemoveNS(string doc)
        {
            return Regex.Replace(doc, @"xmlns[:xsi|:xsd]*="".*?""", String.Empty);
        }

        static void Main(string[] args)
        {
            string url = "http://localhost:19735/api/Values/Empleados";

            var client = new WebClient();
            client.Headers.Add("Accept", "application/xml");
            client.Headers.Add("Content-Type", "application/xml");            
            var result = client.DownloadString(url);
            result = RemoveNS(result);

            XDocument xdoc = XDocument.Parse(result);
            var numeroEmpleados = (from e in xdoc.Descendants("Empleado")
                                   select e).Count();

            var empleadoId = xdoc.Descendants("Empleado").Where(c => (int)c.Element("id") == 2);

            Console.WriteLine(numeroEmpleados.ToString());
            Console.WriteLine(empleadoId.Elements("Name").FirstOrDefault().Value);

            Console.ReadLine();
        }
    }
}
