
using System.Windows.Forms;

namespace Wood_Stocks_App
{
    class CellValidatingMessageBox
    {
        public virtual void errorMessage()
        {
            MessageBox.Show("Enter a whole number greater than or equal to 0.", "Incorrect Input:");
        }
    }
}
