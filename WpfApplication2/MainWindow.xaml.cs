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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MTScraper;
using HtmlAgilityPack;
using Craigslist.org;
using Craigslist.org.View;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        protected MTScraper.Core _scraper;
        protected CL.Core _core;

        public MainWindow()
        {
            InitializeComponent();
            
            new DG.Columns(this.dgResults);
            this._core = new CL.Core(this);
        }

        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            _core = new CL.Core(this);

            String city = "http://auburnlocal.craigslist.org";
            String cat = "Personals";
            String subCat = "stp";
            String kWord = String.Empty;

            _core.Start(new object[] {
                city,
                cat,
                subCat,
                kWord
            });
        }
    }
}
