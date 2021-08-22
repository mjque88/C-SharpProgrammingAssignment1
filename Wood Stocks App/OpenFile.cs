using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    public class OpenFile
    {
        private OpenFileDialog openFile { get; set;}

        public string fileName { get; set;}

        public string initialDirectory { get; set;}

        public bool restoreDirectory { get; set;}

        public DialogResult openFileDialogResult { get; set; }

        public OpenFile(OpenFileDialog openFileDialog)
        { 
            openFile = openFileDialog;
            openFile.InitialDirectory = "C:\\StockFile";
            openFile.RestoreDirectory = false;
            initialDirectory = openFile.InitialDirectory;
            restoreDirectory = openFile.RestoreDirectory;
        }

        public void SelectFile()
        {
            DialogResult openFileDialog1Result = openFile.ShowDialog();
            openFileDialogResult = openFileDialog1Result;
            if (openFileDialog1Result == DialogResult.Cancel)
            {
                MessageBox.Show("Select a CSV file to open.", "Open Error");
            }
            fileName = openFile.FileName;
        }
    }
}
