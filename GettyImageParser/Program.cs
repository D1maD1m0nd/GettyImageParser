// See https://aka.ms/new-console-template for more information

// Load the document using HTMLAgilityPack as normal

using GettyImageParser.model;

var getty = new GettyImage();

var obj = getty.GetData("1303150754");


  
Console.WriteLine(obj.author);
Console.WriteLine(obj.duration);
Console.WriteLine(obj.name);
Console.WriteLine(obj.companyName);
Console.WriteLine(obj.preview);
Console.WriteLine(obj.imageByteArray.Length);

