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

        public string fileName;

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
                OpenFileDialog1Result openFileDialog1Result1 = new OpenFileDialog1Result();
                openFileDialog1Result1.MessageBoxCancel();             
            }
            fileName = openFile.FileName;
            openFileDialogResult = openFileDialog1Result;
        }
    }
}
