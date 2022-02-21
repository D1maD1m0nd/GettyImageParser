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
        string pathCsvFile = @"C:\Users\dima\Downloads\sales_report_items_data_export_798_799_800_2022-02-21.csv";
        var file = File.ReadAllBytes(pathCsvFile);
        var list = new List<PondReport>(100);
        using (var memStream = new MemoryStream(file))
        {
            using (StreamReader streamReader = new StreamReader(memStream))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    // получаем строки
                    var programmingLanguages =
                        csvReader.GetRecords<PondReport>();

                    foreach (var item in programmingLanguages)
                    {
                        list.Add(item);
                    }
                }
            }
        }

        var rufootage1 = list.FindAll(i => i.UserName == "Rufootage1");
        var rufootage2 = list.FindAll(i => i.UserName == "Rufootage2");
        var rufootage3 = list.FindAll(i => i.UserName == "Rufootage3");
        var rufootage4 = list.FindAll(i => i.UserName == "Rufootage4");
        new Thread(a =>WriteCsv(rufootage1, "repord_1")).Start();
        new Thread(a => WriteCsv(rufootage2, "repord_2")).Start();
        new Thread(a =>WriteCsv(rufootage3, "repord_3")).Start();
        new Thread(a =>WriteCsv(rufootage4, "repord_4")).Start();
    }

    public static void WriteCsv<T>( List<T> list, string fileName)
    {
        if (list.Count > 0)
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);
            var file = stream.ToArray();
            File.WriteAllBytes($"{fileName}.csv", file);
        }
    }
}