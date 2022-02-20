// See https://aka.ms/new-console-template for more information

// Load the document using HTMLAgilityPack as normal

using GettyImageParser;
using GettyImageParser.model;

var getty = new GettyImage();

var obj = getty.GetData("1371792562");


  
Console.WriteLine("Author = " + obj.author);
Console.WriteLine("Duration = " + obj.duration);
Console.WriteLine("name = " + obj.name);
Console.WriteLine("Company = " + obj.companyName);
Console.WriteLine("preview = " + obj.preview);
Console.WriteLine(obj.imageByteArray.Length);