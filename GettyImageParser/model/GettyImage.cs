using System.Net;
using System.Runtime.Intrinsics.Arm;
using HtmlAgilityPack;

namespace GettyImageParser.model;

public class GettyImage
{
    public string id { get; set; }
    public string author { get; set; }
    public string name { get; set; }
    public string companyName { get; set; }
    public string preview { get; set; }
    public string duration { get; set; }
    public byte[] imageByteArray { get; set; }
    public string usage { get; set; }

    public GettyImage GetData(string code)
    {
        id = code;
        var url = $"https://www.gettyimages.com/search/2/image?phrase={code}";
        var uri = new Uri(url);
        var html = getHtml(uri);
        var obj = parseHtml(html);
        return obj;
    }
    

    private string getHtml(Uri url)
    {
        using (WebClient client = new WebClient())
        {
            string htmlCode =
                client.DownloadString(url);
            return htmlCode;
        }
    }

    private GettyImage parseHtml(string htmlCode)
    {
        var html = new HtmlDocument();
        html.LoadHtml(htmlCode);
        var document = html.DocumentNode;
  

        var authorNode = document.SelectSingleNode("//meta[@itemprop='author']");
        if (authorNode != null)
        {
            author = authorNode.Attributes["content"].Value;
        }
       
  
        var siteNameNode = document.SelectSingleNode("//meta[@property='og:title']");
        if (siteNameNode != null)
        {
            name = siteNameNode.Attributes["content"].Value;
        }
        
  
        var companyNameNode = document.SelectSingleNode("//meta[@itemprop='creditText']");
        if (companyNameNode != null)
        {
            companyName = companyNameNode.Attributes["content"].Value;
        }

        var previewLinkNode = document.SelectSingleNode("//meta[@property='og:image']");
        if (previewLinkNode != null)
        {
            preview = previewLinkNode.Attributes["content"].Value;
        }

        var durationNode = document.SelectSingleNode("//div[@class='asset-detail asset-detail--location']");
        if (durationNode != null)
        {
            duration = durationNode.PreviousSibling.InnerText;
        }
      
        var usageNode = document.SelectSingleNode("//div[@class='asset-description__title']");
        if (usageNode != null)
        {
            usage = usageNode.InnerText;
        }
       
    
        using (var webClient = new WebClient())
        {
            imageByteArray = webClient.DownloadData(preview);
        }

        return this;
    }
}