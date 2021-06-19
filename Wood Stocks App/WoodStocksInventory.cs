using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    public partial class frmWoodStocksInventory : Form
    {
        // Global Variables
        string currentCount = "Current Count";
        int incorrectInputCount = 0;
        int excemptionLimit = 3;
        bool formClosingClicked = false;


        public frmWoodStocksInventory()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Instatiate OpenFileDialog1
            OpenFile file1 = new OpenFile(openFileDialog1);

            // Prompt user to select CSV file to open
            file1.SelectFile();

            // Display CSV filename open in TextBox
            txtFilename.Text = openFileDialog1.FileName;
            
            // Create TextFile using DataTable
            if (file1.openFileDialogResult == DialogResult.OK)
            {
                dgvStocklist.DataSource = TextFile.CreateDataTable(openFileDialog1.FileName).DataTable;
            }
            else
            {
                return;
            }

            // Check if TextFile is empty
            if (dgvStocklist.ColumnCount == 0)
            {
                return;
            }
            // Make all Columns in DataGridView read only except Current Count
            else
            {
                TextFile csv1 = new TextFile();
                csv1.ReadOnlyExceptCurrentCount(dgvStocklist);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Instatiate saveFileDialog1
            SaveFile saveFile1 = new SaveFile(saveFileDialog1);

            // Check if X button to close form was clicked
            saveFile1.formClosingClicked = formClosingClicked;

            // Initalise SaveFileDialog
            saveFile1.SaveFileDialog();

            // // Display CSV filename to save in TextBox
            txtFilename.Text = saveFileDialog1.FileName;

            // Create CSV file and save to C: Drive location
            saveFile1.SavetoCSV(dgvStocklist, saveFileDialog1);
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
