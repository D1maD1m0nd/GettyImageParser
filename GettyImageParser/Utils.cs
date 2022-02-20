using System.Collections;
using System.Globalization;
using CsvHelper;
using GettyImageParser.model;

namespace GettyImageParser;

public class Utils
{
    public class ProgrammingLanguage
    {
        public string Name { get; set; }
        public string Developer { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public string UUID { get; set; }
        public string Name { get; set; }
    }
    public static void CsvReader()
    {
        // указываем путь к файлу csv
        string pathCsvFile = @"C:\Users\dima\Desktop\test.csv";
 
        using (StreamReader streamReader = new StreamReader(pathCsvFile))
        {
            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                // получаем строки
                var programmingLanguages =
                    csvReader.GetRecords<ProgrammingLanguage>();

                foreach (var item in programmingLanguages)
                {
                    Console.WriteLine($"{item.Developer} {item.Name}");
                }
            }
        }
    }

    public static void WriteCsv()
    {
        var list = new List<Data>(1000);
        var random = new Random();
        for (var i = 0; i < 10000; i++)
        {
            var str = random.Next(1, 1000000).ToString();
            list.Add(new Data
            {
                Id = str,
                Name = (i * random.Next(50, 1233)).ToString(),
                UUID = Guid.NewGuid().ToString()
            });
        }
        string pathCsvFile = @"C:\Users\dima\Desktop\test1.csv";
        using (var writer = new StreamWriter(pathCsvFile))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(list);
        }

    }
}