using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    public partial class frmWoodStocksInventory : Form
    {
        public frmWoodStocksInventory()
        {
            InitializeComponent();
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = "C:\\StockFile";
            openFileDialog1.RestoreDirectory = true;
            File.ReadAllLines(openFileDialog1.FileName);
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
