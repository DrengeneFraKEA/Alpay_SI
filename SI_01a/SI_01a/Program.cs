using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YamlDotNet.Serialization;

namespace SI_01a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\SI_01a\\files\\";

            // Text
            string[] lines = File.ReadAllText(path + "txt.txt").Split(':'); // <-

            // XML
            XDocument doc = XDocument.Load(path + "xml.xml"); // <-

            // YAML
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(File.OpenText(path + "yaml.yaml")); // <-

            // JSON
            var jsonString = File.ReadAllText(path + "json.json");
            var jsonObject = JsonConvert.DeserializeObject(jsonString); // <-

            // CSV
            using (var reader = new StreamReader(path + "csv.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>().ToList(); // <-
            }
        }
    }
}
