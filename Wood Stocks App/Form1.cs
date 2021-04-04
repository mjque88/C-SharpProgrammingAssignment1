using System;
using System.ComponentModel;
using System.Data;
using System.IO;
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = "C:\\StockFile";
                openFileDialog1.RestoreDirectory = true;
                string strFileName = openFileDialog1.FileName;
                LoadData(strFileName);
                MessageBox.Show("Import Successful");
            }
            else
            {
                MessageBox.Show("Import Cancelled");
            }
        }

        
        //Need to create new Class instead of being in Form1?
        private void LoadData(string strFilePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(strFilePath);
            if (lines.Length > 0)
            {
                //Header
                string strfirstLine = lines[0];
                string[] headerLabels = strfirstLine.Split(',');
                foreach (string strheader in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(strheader));
                }
                //Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] strData = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string strheader in headerLabels)
                    {
                        dr[strheader] = strData[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (dt.Rows.Count > 0)
            {
                dgvStocklist.DataSource = dt;
            }
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

        private void dgvStocklist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFilename_Click(object sender, EventArgs e)
        {

        }
    }


}
