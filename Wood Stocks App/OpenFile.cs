using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class OpenFile
    {
        private OpenFileDialog openFile;

        public DialogResult openFileDialogResult;

        public OpenFile(OpenFileDialog openFileDialog)
        { 
            openFile = openFileDialog;
        }

        public void SelectFile()
        {
            DialogResult openFileDialog1Result = openFile.ShowDialog();
            if (openFileDialog1Result == DialogResult.OK)
            {
                openFile.InitialDirectory = "C:\\StockFile";
                openFile.RestoreDirectory = true;
            }
            else if (openFileDialog1Result == DialogResult.Cancel)
            {
                MessageBox.Show("Select a CSV file to open.", "Open Error");
            }
            openFileDialogResult = openFileDialog1Result;
        }
    }
}
