using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS2MVC.Models
{
    public class ProcessRSSUrl
    {
        public static string ProcessRSSItem(string rssurl)
        { 
            System.Net.WebRequest myRequest = System.Net.WebRequest.Create(rssurl);
            System.Net.WebResponse myResponse = myRequest.GetResponse();

            System.IO.Stream rssStream = myResponse.GetResponseStream();
            System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
            rssDoc.Load(rssStream);

            System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
            string title = string.Empty;
            string link = string.Empty;
            string description = string.Empty;
            string content = string.Empty;
            for (int i = 0; i < rssItems.Count; i++)
            {
                System.Xml.XmlNode rssDetail;

                rssDetail = rssItems.Item(i).SelectSingleNode("title");
                if (rssDetail != null)
                {
                    title = rssDetail.InnerText;
                }
                else
                {
                    title = string.Empty;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("link");
                if (rssDetail != null)
                {
                    link = rssDetail.InnerText;
                }
                else
                {
                    link = string.Empty;
                }

                rssDetail = rssItems.Item(i).SelectSingleNode("description");
                if (rssDetail != null)
                {
                    description = rssDetail.InnerText;
                }
                else
                {
                    description = string.Empty;
                }
                content += "<p><b><a href='" + link + "' target='new'>" + title + "</a></b><br/>" + description + "</p>";
            }
            return content;
        }
    }
}
