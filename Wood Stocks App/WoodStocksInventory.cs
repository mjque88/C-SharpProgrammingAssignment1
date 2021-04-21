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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
                openFileDialog1.InitialDirectory = "C:\\StockFile";
                openFileDialog1.RestoreDirectory = true;
                dgvStocklist.DataSource = dt;
                AddColumn();
                AddRows();

                if (dgvStocklist.Columns[0].DataPropertyName == "Column1")
                {
                    dgvStocklist.Columns[0].HeaderCell.Value = "Check the file you opened, possibly empty file or there are no column headers.";

                    MessageBox.Show("Check if correct file opened or column headers are possibly empty.", "Error Info");
                }
                else
                {
                    try
                    {
                        int numberOfColumns = (dgvStocklist.Columns.Count) - 1;
                        {
                            int currentCountIndex = dgvStocklist.Columns["Current Count"].Index;

                            for (int i = numberOfColumns; i >= 0; i--)
                            {
                                dgvStocklist.Columns[i].ReadOnly = true;
                            }

                            if (dgvStocklist.Columns.Contains("Current Count") == true)
                            {
                                dgvStocklist.Columns[currentCountIndex].ReadOnly = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Check Column Headers Error: " + ex.Message);
                    }
                }
            }
            else if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Select a CSV file to open.", "Open Error");
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

            if (lines.Length > 0)
            {
                try
                {
                    dt.Columns.Clear();
                    dt.Rows.Clear();
                    int columnIndex = 0;
                    while (columnIndex < firstline.Length)
                    {
                        int currentCountIndex = Array.IndexOf(firstline, currentCount);
                        if (columnIndex == currentCountIndex)
                        {
                            dt.Columns.Add(currentCount, typeof(int));
                        }
                        else
                        {
                            dt.Columns.Add(firstline[columnIndex]);
                        }
                        columnIndex++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add Column Error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Check if CSV file headers are correct", "Info");
            }
        }

        public void AddRows()
        {
            string[] lines = File.ReadAllLines(openFileDialog1.FileName);
            if (lines.Length > 0)
            {
                try
                {
                    for (int ColumnIndex = 1; ColumnIndex < lines.Length; ColumnIndex++)
                    {
                        string[] data = lines[ColumnIndex].Split(',');
                        DataRow dr = dt.NewRow();
                        int dataColumnIndex = 0;
                        string[] headerLabels = lines[0].Split(',');
                        foreach (string header in headerLabels)
                        {
                            dr[header] = data[dataColumnIndex++];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Add Row Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No Data to Load", "Info");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory = "C:\\StockFile";
                saveFileDialog1.RestoreDirectory = true;

                if (dgvStocklist.Rows.Count > 0)
                {
                    try
                    {
                        int columnCount = dgvStocklist.ColumnCount;
                        int rowCount = dgvStocklist.RowCount + 1;
                        string columnHeaders = "";
                        string[] csvOutput = new string[rowCount];
                        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                        {
                            if (columnIndex == dgvStocklist.ColumnCount - 1)
                            {
                                columnHeaders = columnHeaders + dgvStocklist.Columns[columnIndex].DataPropertyName.ToString();
                            }
                            else
                            {
                                columnHeaders = columnHeaders + dgvStocklist.Columns[columnIndex].DataPropertyName.ToString() + ",";
                            }
                        }
                        csvOutput[0] = columnHeaders;

                        for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
                        {
                            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                            {
                                if (columnIndex == dgvStocklist.ColumnCount - 1)
                                {
                                    csvOutput[rowIndex] = csvOutput[rowIndex] + dgvStocklist.Rows[rowIndex - 1].Cells[columnIndex].Value.ToString();
                                }
                                else
                                {
                                    csvOutput[rowIndex] = csvOutput[rowIndex] + dgvStocklist.Rows[rowIndex - 1].Cells[columnIndex].Value.ToString() + ",";
                                }
                            }
                        }
                        File.WriteAllLines(saveFileDialog1.FileName, csvOutput, System.Text.Encoding.UTF8);
                        MessageBox.Show("File Saved Successfully.", "Info");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Save File Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No Data To Save", "Info");
                }
            }
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
            if (dgvStocklist.CurrentCell.ReadOnly)
            {
                SendKeys.Send("{TAB}");
            }
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

        private void lblOpen_Click(object sender, EventArgs e)
        {

        }

        private void lblSave_Click(object sender, EventArgs e)
        {

        }

        private void frmWoodStocksInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
