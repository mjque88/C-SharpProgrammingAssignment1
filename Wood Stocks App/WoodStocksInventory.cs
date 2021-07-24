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
        int incorrectInputCount = 0;
        bool formClosingClicked = false;
        bool cellValidating = false;


        public frmWoodStocksInventory()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Instantiate OpenFileDialog1
            OpenFile file1 = new OpenFile(openFileDialog1);

            // Prompt user to select CSV file to open
            file1.SelectFile();

            // Display CSV filename open in TextBox
            txtFilename.Text = file1.fileName;
            
            // Create TextFile using DataTable
            if (file1.openFileDialogResult == DialogResult.OK)
            {
                dgvStocklist.DataSource = TextFile.CreateDataTable(file1.fileName).DataTable;
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
            // Instantiate saveFileDialog1
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
            // Cannot tab or select readonly cells
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
            // Validate if cells are interger or if cell is empty.
            // There is a limit of 3 input errors and program will close after reaching this limit.
            int currentCountIndex = dgvStocklist.Columns["Current Count"].Index;
            int excemptionLimit = 3;

            if (e.ColumnIndex != dgvStocklist.Columns[currentCountIndex].Index)
            {
                return;
            }
            else
            {
                try
                {
                    try
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            CellValidatingEmptyCell cellValidatingEmptyCell = new CellValidatingEmptyCell();
                            cellValidatingEmptyCell.errorMessage();
                            e.Cancel = true;
                            incorrectInputCount++;
                            cellValidating = true;
                        }
                        else if (Convert.ToInt32(dgvStocklist.CurrentCell.EditedFormattedValue) < 0)
                        {
                            CellValidatingLessThanZero cellValidatingLessThanZero = new CellValidatingLessThanZero();
                            cellValidatingLessThanZero.errorMessage();
                            e.Cancel = true;
                            incorrectInputCount++;
                            cellValidating = true;
                        }
                    }
                    catch (FormatException)
                    {
                        CellValidatingLettersOrSymbols cellValidatingLettersOrSymbols = new CellValidatingLettersOrSymbols();
                        cellValidatingLettersOrSymbols.errorMessage();
                        incorrectInputCount++;
                        cellValidating = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Enter a whole number greater than or equal to 0. " + ex.Message, "Incorrect Input");
                    incorrectInputCount++;
                    cellValidating = true;
                }

                if (incorrectInputCount >= excemptionLimit)
                {
                    MessageBox.Show("You did not enter a whole number greater than or equal to 0, program will now close.", "Warning: Program Close!");
                    e.Cancel = true;
                    dgvStocklist.CurrentCell.Value = 0;
                    Environment.Exit(0);
                }
            }
        }

        private void dgvStocklist_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Disable FormatException Message
            e.Cancel = true;
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
            // Allow SaveFile class to check if "X" button was pressed
            formClosingClicked = true;

            // Cancel closing and ability to save if invalid cell input
            if (cellValidating == true)
            {
                e.Cancel = true;
                return;
            }
            // Add option to save if "X" button is pressed
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
