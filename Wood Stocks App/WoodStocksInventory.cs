using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    public partial class frmWoodStocksInventory : Form
    {

        DataTable dt = new DataTable();
        string itemCode = "Item Code";
        string itemDescription = "Item Description";
        string currentCount = "Current Count";
        string onOrder = "On Order";
        int incorrectInputCount = 0;
        int excemptionLimit = 3;
        bool formClosingClicked = false;

        public frmWoodStocksInventory()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile file1 = new OpenFile(openFileDialog1);
            file1.SelectFile();
            txtFilename.Text = openFileDialog1.FileName;

            dgvStocklist.DataSource = TextFile.CreateDataTable(openFileDialog1.FileName).DataTable;


            if (dgvStocklist.Columns[0].DataPropertyName == "Column1")
            {
                dgvStocklist.Columns[0].HeaderCell.Value = "Check the file you opened, possibly empty file or there are no column headers.";

                MessageBox.Show("Check if correct file opened or column headers are possibly empty.", "Error Info");
            }
            else
            {
                try
                {
                    int currentCountIndex = dgvStocklist.Columns[currentCount].Index;
                    int numberOfColumns = (dgvStocklist.Columns.Count) - 1;
                    {

                        for (int i = numberOfColumns; i >= 0; i--)
                        {
                            dgvStocklist.Columns[i].ReadOnly = true;
                        }

                        if (dgvStocklist.Columns.Contains(currentCount) == true)
                        {
                            dgvStocklist.Columns[currentCountIndex].ReadOnly = false;
                        }
                    }
                    dgvStocklist.CurrentCell = dgvStocklist.Rows[0].Cells[currentCountIndex];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Check column headers error: " + ex.Message);
                }
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
                    MessageBox.Show("Add row error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No data to load", "Info");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult saveFileDialog1Result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1Result == DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory = "C:\\StockFile";
                saveFileDialog1.RestoreDirectory = true;
                txtFilename.Text = saveFileDialog1.FileName;

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
                        if (formClosingClicked == true && saveFileDialog1Result == DialogResult.OK)
                        {
                            MessageBox.Show("File saved successfully, program will now exit.", "Info");
                            Dispose();
                            Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show("File saved successfully.", "Info");
                        }
                        
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Save file error: " + ex.Message);
                    }
                }
                else
                {
                    formClosingClicked = false;
                    MessageBox.Show("No data to save", "Info");
                }
            }
            else if (saveFileDialog1Result == DialogResult.Cancel)
            {
                formClosingClicked = false;
                return;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            

        }

        private void dgvStocklist_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int lastRow = dgvStocklist.Rows.Count - 1;
            int lastColumn = dgvStocklist.Columns.Count -1;
            if (dgvStocklist.CurrentCell == dgvStocklist.Rows[lastRow].Cells[lastColumn])
            {
                SendKeys.Send("{LEFT}");
            }
            else if (dgvStocklist.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgvStocklist_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            int currentCountIndex = dgvStocklist.Columns[currentCount].Index;

            if (e.ColumnIndex != dgvStocklist.Columns[currentCountIndex].Index)
            {
                return;
            }
            else
            {
                try
                {
                    if (dgvStocklist.CurrentCell.ValueType != typeof(int))
                    {
                        MessageBox.Show("Enter whole numbers only or 0 if no stock.", "Incorrect Input");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter whole numbers only or 0 if no stock." + ex.Message, "Incorrect Input");
                }
            }
        }

        private void dgvStocklist_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

            if ((e.Exception is FormatException))
            {
                string messsageIncorrectInput = "Enter whole numbers only or 0 if no stock.";
                string titleIncorrectInput = "Incorrect Input";
                MessageBoxButtons buttonIncorrectInput = MessageBoxButtons.OK;
                DialogResult resultIncorrectInput = MessageBox.Show(messsageIncorrectInput, titleIncorrectInput, buttonIncorrectInput);
                if(resultIncorrectInput == DialogResult.OK)
                {
                    incorrectInputCount++;
                }
                if (incorrectInputCount >= excemptionLimit)
                {
                    MessageBox.Show("You did not enter a whole number or 0, program will now close.", "Warning: Program Close!");
                    Dispose();
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Unknown Error, please contact administrator", "Unknown Error");
            }
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

        private void lblOpen_Click(object sender, EventArgs e)
        {

        }

        private void lblSave_Click(object sender, EventArgs e)
        {

        }

        private void frmWoodStocksInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClosingClicked = true;
            string messageConfirmExit = "Do you want to Save before you Exit the program?";
            string titleConfirmExit = "Save and Exit Program";
            MessageBoxButtons buttonConfirmExit = MessageBoxButtons.YesNoCancel;
            DialogResult resultConfirmExit = MessageBox.Show(messageConfirmExit, titleConfirmExit, buttonConfirmExit);
            if (resultConfirmExit == DialogResult.Yes)
            {
                btnSave_Click(sender, e);
                e.Cancel = true;
            }
            else if (resultConfirmExit == DialogResult.No)
            {
                Dispose();
                Environment.Exit(0);
            }
            else if(resultConfirmExit == DialogResult.Cancel)
            {
                formClosingClicked = false;
                e.Cancel = true;
                return;
            }
        }
    }
}
