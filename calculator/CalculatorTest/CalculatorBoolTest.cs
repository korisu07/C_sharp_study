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

            Assert.AreEqual<bool>(NumberBool, base.BoolEnteredNumber, "数字に関する例外が発生しました");
            Assert.AreEqual<bool>(SymbolBool, base.BoolEnteredCalc, "計算記号に関する例外が発生しました");

        }

    }
}
