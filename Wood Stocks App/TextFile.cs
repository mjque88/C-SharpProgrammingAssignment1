using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class TextFile
    {
        public DataColumn ItemCode { get; set; }
        public DataColumn ItemDescription { get; set; }
        public DataColumn CurrentCount { get; set; }
        public DataColumn OnOrder { get; set; }
        public DataTable DataTable { get; set; }

        public TextFile()
        {
        }

        public void CreateColumnHeaders()
        {

        }

        public void ReadOnlyExceptCurrentCount(DataGridView dataGridView)
        {
            try
            {
                int currentCountIndex = dataGridView.Columns["Current Count"].Index;
                int numberOfColumns = (dataGridView.Columns.Count) - 1;
                {

                    for (int i = numberOfColumns; i >= 0; i--)
                    {
                        dataGridView.Columns[i].ReadOnly = true;
                    }

                    if (dataGridView.Columns.Contains("Current Count") == true)
                    {
                        dataGridView.Columns[currentCountIndex].ReadOnly = false;
                    }
                }

                if (dataGridView.RowCount != 0)
                {
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[currentCountIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check column headers error: " + ex.Message);
            }
        }

        public static TextFile CreateDataTable(string filename)
        {
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filename);
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
                        int dataTableCurrentCountIndex = Array.IndexOf(firstline, "Current Count");
                        if (columnIndex == dataTableCurrentCountIndex)
                        {
                            dt.Columns.Add("Current Count", typeof(int));
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
                    MessageBox.Show("Add column error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Check if CSV file headers are correct", "Info");
            }

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

            TextFile csv1 = new TextFile();

            int itemCodeIndex = dt.Columns.IndexOf("Item Code");
            int itemDescriptionIndext = dt.Columns.IndexOf("Item Description");
            int currentCountIndex = dt.Columns.IndexOf("Current Count");
            int onOrderIndex = dt.Columns.IndexOf("On Order");

            // continue exception handling for incorrect headers values
            if(dt.Columns.IndexOf("Item Code") != 0 || dt.Columns.IndexOf("Item Description") != 1 || dt.Columns.IndexOf("Current Count") != 2 || dt.Columns.IndexOf("On Order") != 3)
            {
                MessageBox.Show("Check if correct file opened or column headers are possibly empty.", "Error Info");
            }
            else
            {
                csv1.ItemCode = dt.Columns[itemCodeIndex];
                csv1.ItemDescription = dt.Columns[itemDescriptionIndext];
                csv1.CurrentCount = dt.Columns[currentCountIndex];
                csv1.OnOrder = dt.Columns[onOrderIndex];
                csv1.DataTable = dt;
            }
       
            return csv1;
        }
    }
}
