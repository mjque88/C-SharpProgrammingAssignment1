using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class OpenFileDialog1Result
    {
        private bool OpenFileDialog1ResultCancel { get; set; }

        public OpenFileDialog1Result()
        {
            OpenFileDialog1ResultCancel = false;
        }

        public bool MessageBoxCancel()
        {
            MessageBox.Show("Select a CSV file to open.", "Open Error");
            OpenFileDialog1ResultCancel = true;
            return OpenFileDialog1ResultCancel;
        }

        public bool CheckResultCancel()
        {
           return OpenFileDialog1ResultCancel;
        }
    }
}
