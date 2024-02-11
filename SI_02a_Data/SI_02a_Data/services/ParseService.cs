using CsvHelper;
using SI_02a_Data.DTO;
using System.Globalization;
using System.Text.Json;
using System.Xml.Linq;
using YamlDotNet.Serialization;

namespace SI_02a_Data.services
{
    public class ParseService
    {
        private readonly string path = Directory.GetCurrentDirectory() + "\\files\\";
        public string ParseTxt() 
        {
            return File.ReadAllText(path + "txt.txt");
        }

        public string ParseXml() 
        {
            return XDocument.Load(path + "xml.xml").ToString();
        }

        public string ParseCsv() 
        {
            List<dynamic> records = new List<dynamic>();
            using (var reader = new StreamReader(path + "csv.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<dynamic>().ToList();
            }

            List<CsvDTO> csvData = new List<CsvDTO>();
            foreach (dynamic record in records) 
            {
                int tempCounter = 0;
                CsvDTO csv = new CsvDTO();

                // Iterate over each key-value pair in the record
                foreach (var property in record)
                {
                    if (tempCounter == 0) csv.Name = property.Value;
                    else if (tempCounter == 1) csv.Age = int.Parse(property.Value);
                    else csv.Roles = ((string)property.Value).Split(".");

                    tempCounter++;
                }

                csvData.Add(csv);
            }

            return JsonSerializer.Serialize(csvData);
        }

        public string ParseYaml() 
        {
            var deserializer = new DeserializerBuilder().Build();
            Dictionary<string, object> yamlDictionary = deserializer.Deserialize<Dictionary<string, object>>(File.OpenText(Path.Combine(path, "yaml.yaml")));

            return JsonSerializer.Serialize(yamlDictionary);
        }

        public string ParseJson() 
        {
            string? jsonString = File.ReadAllText(path + "json.json");

            return JsonSerializer.Serialize(jsonString);
        }
    }
}
