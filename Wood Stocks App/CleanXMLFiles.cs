using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood_Stocks_App
{
    class CleanXMLFiles
    {
        public string LocalApplicationData;
        public string RawXMLSaveLocation;
        public string Style1XMLSaveLocation;
        public string Style2XMLSaveLocation;

        public CleanXMLFiles()
        {
            LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            RawXMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML.xml";
            Style1XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 1.xml";
            Style2XMLSaveLocation = $@"{LocalApplicationData}\WoodStocksApp\XML Files\stocklist XML Style 2.xml";
        }

        public void RemoveXMLFiles()
        {
            if (File.Exists(RawXMLSaveLocation))
            {
                File.Delete(RawXMLSaveLocation);
            }

            if (File.Exists(Style1XMLSaveLocation))
            {
                File.Delete(Style1XMLSaveLocation);
            }

            if (File.Exists(Style2XMLSaveLocation))
            {
                File.Delete(Style2XMLSaveLocation);
            }
        }
    }
}
