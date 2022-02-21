// See https://aka.ms/new-console-template for more information

// Load the document using HTMLAgilityPack as normal

using System.Collections;
using GettyImageParser;
using GettyImageParser.model;

var getty = new GettyImage();

var obj = getty.GetData("1371792562");

Hashtable ht = new Hashtable();
ht.Add("#21","321321");
foreach (string item in ht.Keys)
{
    Console.WriteLine(ht[item]);
}
  
Console.WriteLine("Author = " + obj.author);
Console.WriteLine("Duration = " + obj.duration);
Console.WriteLine("name = " + obj.name);
Console.WriteLine("Company = " + obj.companyName);
Console.WriteLine("preview = " + obj.preview);
Console.WriteLine(obj.imageByteArray.Length);