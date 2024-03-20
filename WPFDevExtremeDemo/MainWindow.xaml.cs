using DevExpress.Spreadsheet;
using DevExpress.Xpf.Core;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WPFDevExtremeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitWebView();
        }

        string GridData { get; set; }

        async void InitWebView()
        {
            await webView.EnsureCoreWebView2Async(null);
            string fileName = $"{Environment.CurrentDirectory}\\grid.html";
            if (File.Exists(fileName))
            {
                webView.Source = new Uri($"file://{fileName}");
            }
            webView.CoreWebView2.WebMessageReceived += webViewMessageReceived;
        }

        void webViewMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            GridData = args.WebMessageAsJson;
        }

        private void simpleButton_Click(object sender, RoutedEventArgs e)
        {
            DevExpress.Spreadsheet.Worksheet sheet = dxSpreadSheet.Document.Worksheets[0];

            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(GridData);

            Product productHeadings = new()
            {
                Name = "Name",
                Category = "Category",
                CurrentInventory = "CurrentInventory",
                RetailPrice = "Retail Price"
            };
            productList.Insert(0, productHeadings);

            int rowIndex = 1;
            CellRange range;
            for (int i = 0; i < productList.Count; i++)
            {
                string tableRow = String.Format("{0}:{0}", rowIndex);
                range = sheet[tableRow];
                sheet.DataBindings.BindToDataSource(productList[i], range);
                rowIndex++;
            }
            dxSpreadSheet.Document.Worksheets[0].DataBindings.Clear();
        }
    }
}
