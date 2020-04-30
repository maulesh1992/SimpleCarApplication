//Project:  CarsSimpleApplication (Montu's Car Inventory Application)
//Creator:   Montu Patel
//File:      CarData.CS

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarsSimpleApplication
{
    class CarData
    {
        private string FileName;
        private List<Cars> FileContents;
        public CarData(string fileName)
        {
            FileName = fileName;
            FileContents = ReadCarStats();
        }
        // Reading file from storage
        public List<Cars> ReadCarStats()
        {
            var CarStats = new List<Cars>();
            using (var reader = new StreamReader(FileName)) // open and read file
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null) //load line into string
                {
                    string[] values = line.Split(','); // separate the values by their comma
                    int parseInt;
                    int.TryParse(values[0], out parseInt);
                    var row = new Cars(parseInt);
                    row.Year = values[1];
                    row.Make = values[2];
                    row.Model = values[3];
                    row.Color = values[4];

                    CarStats.Add(row);  // adding title Row into a save file
                }
            }
            return CarStats;
        }
        // saves files in a storage
        public void SaveCSV(List<Cars> fileContents)
        {
            List<string> carStrings = new List<string>();
            string fileString = "ID, Year, Make, Model, Color\n";
            foreach (Cars savecar in fileContents)
            {
                fileString += $"{savecar.ID},{savecar.Year},{savecar.Make},{savecar.Model},{savecar.Color}\n";
            }
            File.WriteAllText(FileName, fileString, Encoding.UTF8);
        }
    }
}
