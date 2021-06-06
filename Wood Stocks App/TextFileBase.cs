using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    internal class TextFileBase
    {
        public string itemCode;
        public string itemDescription;
        public int currentCount;
        public string onOrder;


        public static DataTable CreateDataTable(string filename)
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
                        int currentCountIndex = Array.IndexOf(firstline, "Current Count");
                        if (columnIndex == currentCountIndex)
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
            return dt;
        }
    }
}