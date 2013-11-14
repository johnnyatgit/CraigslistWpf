using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Craigslist.org;
using Craigslist.org.View;

namespace Craigslist.org
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {

        protected MTScraper.Core _scraper;
        protected CL.Core _core;

        public Search()
        {
            InitializeComponent();
            new DG.Columns(this.dgResults);
        }

        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            if ((String)this.btnSearch.Content == "Stop")
            {
                this.btnSearch.Content = "Search";
                this._core.stop();
            }
            else
            {
                new DG.Columns(this.dgResults);

                this.btnSearch.Content = "Stop";
                this._initSearch();
            }
        }

        private void _initSearch()
        {
            this._core = new CL.Core(this);

            String city = "http://auburn.craigslist.org";
            String cat = "Personals";
            String subCat = "stp";
            String kWord = String.Empty;

            this._core.Start(new object[] {
                city,
                cat,
                subCat,
                kWord
            });

        }

    }
}
