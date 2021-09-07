using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Wood_Stocks_App
{
    class ConvertToXML
    {

        private OpenFileDialog OpenFile;
        private XDocument StockListXML;
        public string LocalApplicationData;
        public string RawXMLSaveLocation;
        public string Style1XMLSaveLocation;
        public string Style2XMLSaveLocation;

        public ConvertToXML (OpenFileDialog openFileDialog)
        {
            OpenFile = openFileDialog;
            LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            RawXMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML.xml";
            Style1XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 1.xml";
            Style2XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 2.xml";
        }

        public void CreateXML()
        {
            string[] stockListLines = File.ReadAllLines(OpenFile.FileName);
            int index = 0;

            var stockListXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XElement("StockList",
                    from str in stockListLines
                    let fields = str.Split(',')
                    select new XElement("StockItem",
                        new XAttribute("ID", Convert.ToString(index++)),
                        new XElement("ItemCode", fields[0]),
                        new XElement("ItemDescription", fields[1]),
                        new XElement("CurrentCount", fields[2]),
                        new XElement("OnOrder", fields[3])
                    )
                )
            );

            stockListXML.Element("StockList").FirstNode.Remove();
            StockListXML = stockListXML;
        }

        public void SaveRawXML()
        {
            Directory.CreateDirectory($@"{LocalApplicationData}\\WoodStocksApp\\XML Files");
            StockListXML.Save(RawXMLSaveLocation);
        }

        public void CreateXMLStyle1()
        {
            string[] stockListLines = File.ReadAllLines(OpenFile.FileName);
            int index = 0;

            var stockListXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"C:\\Program Files (x86)\\Skillage IT\\WoodStocksAppSetup\\CSS Style Sheets\\stocklist XML Style 1.css\""),
                    new XElement("StockList",
                        from str in stockListLines
                        let fields = str.Split(',')
                        select new XElement("StockItem",
                        new XAttribute("ID", Convert.ToString(index++)),
                            new XAttribute("class", "StockItem"),
                            new XElement("ItemCode", fields[0]),
                            new XElement("ItemDescription", fields[1]),
                            new XElement("CurrentCount", fields[2]),
                            new XElement("OnOrder", fields[3])
                    )
                )
            );

            stockListXML.Element("StockList").FirstNode.Remove();
            stockListXML.Save(Style1XMLSaveLocation);
        }

        public void CreateXMLStyle2()
        {
            string[] stockListLines = File.ReadAllLines(OpenFile.FileName);
            int index = 0;

            var stockListXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"C:\\Program Files (x86)\\Skillage IT\\WoodStocksAppSetup\\CSS Style Sheets\\stocklist XML Style 2.css\""),
                    new XElement("StockList",
                        from str in stockListLines
                        let fields = str.Split(',')
                        select new XElement("StockItem",
                        new XAttribute("ID", Convert.ToString(index++)),
                            new XAttribute("class", "StockItem"),
                            new XElement("ItemCode", fields[0]),
                            new XElement("ItemDescription", fields[1]),
                            new XElement("CurrentCount", fields[2]),
                            new XElement("OnOrder", fields[3])
                    )
                )
            );

            stockListXML.Element("StockList").FirstNode.Remove();
            stockListXML.Save(Style2XMLSaveLocation);
        }
    }
}
