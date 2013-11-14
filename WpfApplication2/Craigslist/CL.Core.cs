using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Craigslist.org.Tags;
using WpfApplication2;
using MTScraper;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Craigslist.org.View;
using System.Windows;

namespace Craigslist.org
{
    public partial class CL
    {
        public class Core
        {

            protected MTScraper.Core _scraper = null;
            private MainWindow mainWindow;
            private String _url = String.Empty;
            private Search _search;
            public Boolean _searching = false;

            public Core(MainWindow mainWindow)
            {
                // TODO: Complete member initialization
                this.mainWindow = mainWindow;
            }

            public Core(Search search)
            {
                // TODO: Complete member initialization
                //this._scraper = new MTScraper.Core();
                this._search = search;
            }

            public void Start(object[] args)
            {
                this._searching = true;
                this._scraper = new MTScraper.Core(100, 1000);

                string q = String.Empty;

                switch ((String)args[1])
                { 
                    case "Personals":
                        ST.Personals p = new ST.Personals();
                        q = p.Build(new object[] { 1, 25, false, false });
                        break;

                    case "Housing":
                        ST.Housing h = new ST.Housing();
                        q = h.Build(new object[] { });
                        break;

                    case "Gigs":
                        ST.Gigs g = new ST.Gigs();
                        q = g.Build(new object[] { });
                        break;

                    case "Jobs":
                        ST.Jobs j = new ST.Jobs();
                        q = j.Build(new object[] { });
                        break;

                    case "For Sale":
                        ST.ForSale f = new ST.ForSale();
                        q = f.Build(new object[] { });
                        break;

                    default:
                        ST.Default d = new ST.Default();
                        q = d.Build(new object[] { });
                        break;
                }

                _url = String.Format("{0}/search/{1}?{2}{3}", args[0], args[2], formatKeyWord((String)args[3]), q);

                //MessageBox.Show(_url);

                this._scraper.getSource(_url, scrapeSource);

            }

            #region <-Formatters

            private string formatUri(string url, string href)
            {
                Uri uri = new Uri(formatHttp(url));
                try
                {
                    Uri hrefuri = new Uri(formatHttp(href));
                    return href;
                }
                catch
                {
                    return String.Format("{0}{1}", formatHttp(uri.Host.ToString()), href);
                }
            }
            
            public string formatHttp(string url)
            {
                url = Regex.Replace(url, @"\b(?:http://|www\.)", "", RegexOptions.IgnoreCase);
                return String.Format("http://{0}", url);
            }

            private String formatKeyWord(string keyword)
            {
                return String.Format("query={0}", keyword);
            }

            #endregion

            private void scrapeSource(String pageSource)
            {
                HtmlDOM dom = new HtmlDOM(pageSource);

                foreach (HtmlNode node in dom.getNodes("//p[@class=\"row\"]/span[@class=\"pl\"]/a[@href]"))
                {
                    //if (!this._searching) { break; };
                    String href = dom.getAttribute(node, "href", String.Empty);
                    this._scraper.getSource(formatUri(_url,href), scrapeData);
                }
            }

            private void scrapeData(String pageSource)
            {
                _search.dgResults.Dispatcher.Invoke((Action)(() =>
                {
                    HtmlDOM dom = new HtmlDOM(pageSource);

                    try
                    {
                        String title = dom.getNode("//html/head/title").InnerHtml;
                        _search.dgResults.Items.Add(new DG.Items() { title = title, counter = _search.dgResults.Items.Count + 1});
                    }
                    catch { }
                }));
            }

            internal void stop()
            {
                this._searching = false;
                this._scraper.destroy();
                this._scraper = null;
            }
        }
    }
}
