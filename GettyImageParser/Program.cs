

using System.Collections;
using GettyImageParser;
using GettyImageParser.model;
using CsvHelper;
Utils.CsvReader();

string[] users = {"Rufootage1, R", "Rufootage1, 23333333333333333333333333333333333333333333333333333333333","Rufootage1, 3","Rufootage1, 43",};

Parallel.ForEach(users, number =>
{
    Console.WriteLine(number);
});

Console.WriteLine("end");