using System.Net;
using HtmlAgilityPack;

namespace GettyImageParser.model;

public class GettyImage
{
    public string author { get; set; }
    public string name { get; set; }
    public string companyName { get; set; }
    public string preview { get; set; }
    public string duration { get; set; }
    public byte[] imageByteArray { get; set; }

    public GettyImage GetData(string code)
    {
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
        author = authorNode.Attributes["content"].Value;
  
        var siteNameNode = document.SelectSingleNode("//meta[@property='og:site_name']");
        name = siteNameNode.Attributes["content"].Value;
  
        var companyNameNode = document.SelectSingleNode("//meta[@itemprop='creditText']");
        companyName = companyNameNode.Attributes["content"].Value;

        var previewLinkNode = document.SelectSingleNode("//meta[@property='og:image']");
        preview = previewLinkNode.Attributes["content"].Value;
  
        var durationNode = document.SelectSingleNode("//div[@class='asset-detail asset-detail--location']");
        duration = durationNode.PreviousSibling.InnerText;
  
    
        using (var webClient = new WebClient())
        {
            imageByteArray = webClient.DownloadData(preview);
        }

        return this;
    }
}