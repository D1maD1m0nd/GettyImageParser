// See https://aka.ms/new-console-template for more information

// Load the document using HTMLAgilityPack as normal

using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

var html = new HtmlDocument();
html.LoadHtml(@"
  <html>
      <head>
        <meta content='Getty Images' property='og:site_name'>
        <meta content='Russian Footage' itemprop='creditText' />
          <meta
        content='https://media.gettyimages.com/videos/an-aerial-view-of-a-moscow-cityscape-in-winter-day-video-id1303150754?s=170x170'
    property='og:image' />                                           </head>
      <body>
        <div>
          <p class='content'>Fizzler</p>
          <p>CSS Selector Engine</p></div>
      </body>
  </html>");

// Fizzler for HtmlAgilityPack is implemented as the
// QuerySelectorAll extension method on HtmlNode

var document = html.DocumentNode;

// yields: [<p class="content">Fizzler</p>]
document.QuerySelectorAll(".content");

// yields: [<p class="content">Fizzler</p>,<p>CSS Selector Engine</p>]
document.QuerySelectorAll("p");

// yields empty sequence
document.QuerySelectorAll("body>p");

// yields [<p class="content">Fizzler</p>,<p>CSS Selector Engine</p>]
document.QuerySelectorAll("body p");

// yields [<p class="content">Fizzler</p>]
document.QuerySelectorAll("p:first-child");

var siteNameNode = document.SelectSingleNode("//meta[@property='og:site_name']");
var name = siteNameNode.Attributes["content"].Value;
Console.WriteLine(name);
var companyNameNode = document.SelectSingleNode("//meta[@itemprop='creditText']");
var companyName = companyNameNode.Attributes["content"].Value;
Console.WriteLine(companyName);

var previewLinkNode = document.SelectSingleNode("//meta[@property='og:image']");
var preview = previewLinkNode.Attributes["content"].Value;
Console.WriteLine(preview);