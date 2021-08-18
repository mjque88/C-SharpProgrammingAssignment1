using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class CellValidatingMessageBox
    {
        public virtual void errorMessage()
        {
            string messageBoxTextBody = "Enter a whole number greater than or equal to 0.";
            string messageBoxTextHeader = "Incorrect Input:";
            MessageBox.Show(messageBoxTextBody, messageBoxTextHeader);
        }
    }
}
