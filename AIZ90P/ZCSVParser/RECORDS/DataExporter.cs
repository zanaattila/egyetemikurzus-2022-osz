using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZCSVParser.DATATYPES;

namespace ZCSVParser.RECORDS
{
    public static class DataExporter
    {
        public static void ExportNapiAdagXML(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdag>));
            var adat = DataCollector.CollectDataForNapiAdag(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdag_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                xs.Serialize(stream, adat);
            }
        }

        public static void ExportNapiAdagPerEtkezesFajta(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdagPerEtkezesFajta>));
            var adat = DataCollector.CollectDataForNapiAdagPerEtkezesFajta(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdagPerEtkezesFajta_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                try
                {
                    xs.Serialize(stream, adat);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Hiba történt az XML szérializálásakor");
                }
            }
        }

        public static void ExportNapiAdagPerFogyasztoKod(List<RendelesInput> sorok)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NapiAdagPerFogyasztoKod>));
            var adat = DataCollector.CollectDataForNapiAdagPerFogyasztoKod(sorok);
            using (var stream = File.Create(Path.Combine(GLOBALS.OutputPath, $"NapiAdagPerFogyasztoKod_osszesito_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xml")))
            {
                try
                {
                    xs.Serialize(stream, adat);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Hiba történt az XML szérializálásakor");
                }
            }
        }
    }
}
