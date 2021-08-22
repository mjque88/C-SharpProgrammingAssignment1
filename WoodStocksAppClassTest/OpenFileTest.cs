using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Wood_Stocks_App;

namespace WoodStocksAppClassTest
{
    [TestClass]
    public class OpenFileTest
    {
        [TestMethod]
        public void OpenFileInitialDirectory()
        {
            //Arrange
            OpenFileDialog openFileDialogTest = new OpenFileDialog();
            OpenFile file1 = new OpenFile(openFileDialogTest);

            //Act
            string openFileInitialDirectory = "C:\\StockFile";

            //Assert
            Assert.AreEqual(openFileInitialDirectory, file1.initialDirectory);
        }

        [TestMethod]
        public void OpenFileRestoreDirectory()
        {
            //Arrange
            OpenFileDialog openFileDialogTest = new OpenFileDialog();
            OpenFile file1 = new OpenFile(openFileDialogTest);

            //Act
            bool openFileRestoreDirectory = false;

            //Assert
            Assert.AreEqual(openFileRestoreDirectory, file1.restoreDirectory);
        }
    }
}
