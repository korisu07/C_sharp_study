using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using calculator;


namespace CalculatorTest
{
    [TestClass]
    public class CalculatorBoolTest : MainWindow
    {
        [TestMethod]
        public void TestBoolMethod( bool NumberBool, bool SymbolBool )
        {
            MainWindow MainClass = new MainWindow();

            Assert.AreEqual<bool>(NumberBool, base.BoolEnteredNumber, "�����Ɋւ����O���������܂���");
            Assert.AreEqual<bool>(SymbolBool, base.BoolEnteredCalc, "�v�Z�L���Ɋւ����O���������܂���");

        }

    }
}
