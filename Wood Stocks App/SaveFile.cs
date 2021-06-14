using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class SaveFile
    {
        private SaveFileDialog saveFile;
        public DialogResult saveFileDialogResult;
        public bool formClosingClicked { get; set; }

        public SaveFile()
        {
            
        }

        public SaveFile(SaveFileDialog saveFileDialog)
        {
            saveFile = saveFileDialog;
        }
        
        public void SaveFileDialog()
        {
            saveFileDialogResult = saveFile.ShowDialog();
            if (saveFileDialogResult == DialogResult.OK)
            {
                saveFile.InitialDirectory = "C:\\StockFile";
                saveFile.RestoreDirectory = true;
            }
            else if (saveFileDialogResult == DialogResult.Cancel)
            {
                return;
            }
        }

        public void SavetoCSV(DataGridView dataGridView, SaveFileDialog saveFileDialog)
        {
            if (dataGridView.Rows.Count > 0 && saveFileDialogResult == DialogResult.OK)
            {
                try
                {
                    int columnCount = dataGridView.ColumnCount;
                    int rowCount = dataGridView.RowCount + 1;
                    string columnHeaders = "";
                    string[] csvOutput = new string[rowCount];
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        if (columnIndex == dataGridView.ColumnCount - 1)
                        {
                            columnHeaders = columnHeaders + dataGridView.Columns[columnIndex].DataPropertyName.ToString();
                        }
                        else
                        {
                            columnHeaders = columnHeaders + dataGridView.Columns[columnIndex].DataPropertyName.ToString() + ",";
                        }
                    }
                    csvOutput[0] = columnHeaders;

                    for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                        {
                            if (columnIndex == dataGridView.ColumnCount - 1)
                            {
                                csvOutput[rowIndex] = csvOutput[rowIndex] + dataGridView.Rows[rowIndex - 1].Cells[columnIndex].Value.ToString();
                            }
                            else
                            {
                                csvOutput[rowIndex] = csvOutput[rowIndex] + dataGridView.Rows[rowIndex - 1].Cells[columnIndex].Value.ToString() + ",";
                            }
                        }
                    }
                    File.WriteAllLines(saveFileDialog.FileName, csvOutput, System.Text.Encoding.UTF8);
                    if (formClosingClicked == true && saveFileDialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("File saved successfully, program will now exit.", "Info");
                        Environment.Exit(0);
                    }
                    else if(saveFileDialogResult == DialogResult.Cancel)
                    {
                        return;
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
            else if(dataGridView.Rows.Count > 0 && saveFileDialogResult == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                formClosingClicked = false;
                MessageBox.Show("No data to save", "Info");
            }
        }
    }
}
