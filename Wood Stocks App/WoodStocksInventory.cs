using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
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
                dgvStocklist.DataSource = dt;
                AddColumn();
                AddRows();
            }

            int numberOfColumns = (dgvStocklist.Columns.Count) - 1;
            int currentCountIndex = dgvStocklist.Columns["Current Count"].Index;

            for (int i = numberOfColumns; i >= 0; i--)
            {
                dgvStocklist.Columns[i].ReadOnly = true;
            }

            if (dgvStocklist.Columns.Contains("Current Count") == true)
            {
                dgvStocklist.Columns[currentCountIndex].ReadOnly = false;
                dgvStocklist.Columns[currentCount].DisplayIndex = 2;
            }
        }

        DataTable dt = new DataTable();
        string itemCode = "Item Code";
        string itemDescription = "Item Description";
        string currentCount = "Current Count";
        string onOrder = "On Order";

        public void AddColumn()
        {
            string[] lines = File.ReadAllLines(openFileDialog1.FileName);
            string[] firstline = lines[0].Split(',');
            if (lines.Length >0)
            {
                for (int i = 0; i < firstline.Length; i++)
                {
                    int currentCountIndex = Array.IndexOf(firstline, currentCount);
                    if (i == currentCountIndex)
                    {
                        continue;
                    }
                    dt.Columns.Add(firstline[i]);
                }
                if (firstline.Contains(currentCount))
                {
                    dt.Columns.Add(currentCount, typeof(int));
                }
            }
        }

        public void AddRows()
        {
            string[] lines = File.ReadAllLines(openFileDialog1.FileName);
            if (lines.Length > 0)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    string[] headerLabels = { itemCode, itemDescription, currentCount, onOrder };
                    foreach (string header in headerLabels)
                    {
                        dr[header] = data[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
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

        private void frmWoodStocksInventory_Load(object sender, EventArgs e)
        {

        }
    }


}
