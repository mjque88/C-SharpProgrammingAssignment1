using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class OpenXMLWebBrowser
    {
        public string LocalApplicationData;
        public string Style1XMLSaveLocation;
        public string Style2XMLSaveLocation;

        public OpenXMLWebBrowser()
        {
            LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Style1XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 1.xml";
            Style2XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 2.xml";
        }


        public void OpenXMLUsingWinOSBrowserXMLStyle1()
        {
            try
            {
                string targetXML = Style1XMLSaveLocation;
                if (File.Exists(targetXML))
                {
                    Process.Start("IExplore.exe", targetXML);
                }
                else
                {
                    MessageBox.Show("Open stocklist.csv file to create XML file", "Error: No XML File");
                }
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message, "Error: Contact Administrator");
            }
        }

        public void OpenXMLUsingWinOSBrowserXMLStyle2()
        {
            try
            {
                string targetXML = Style2XMLSaveLocation;
                if (File.Exists(targetXML))
                {
                    Process.Start("IExplore.exe", targetXML);
                }
                else
                {
                    MessageBox.Show("Open stocklist.csv file to create XML file", "Error: No XML File");
                }
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message, "Error: Contact Administrator");
            }
        }

    }
}
