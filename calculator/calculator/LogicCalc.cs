using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace calculator
{
    public class LogicCalc : MainWindow
    {
        // 計算結果を一時的に格納する変数
        private int TemporaryNumber;


        private List<String> TemporaryCalcList = new List<String>();

        private bool BoolSwitchBrackets = false;


        // 括弧があるかどうかを判断するための関数
        private void Brackets(String CalcStr )
        {
            // 括弧かどうかを判定
            switch ( CalcStr )
            {
                // はじめ括弧である場合
                case "(":

                    //フラグをON
                    this.BoolSwitchBrackets = true;
                    break;

                // おわり括弧である場合
                case ")":

                    // フラグをOFF
                    this.BoolSwitchBrackets = false;
                    break;


                // 数字や計算記号である場合
                default:
                    // なにもしない
                    break;
                       
            } // end switch.

        } // end func Brackets.


        //// 計算を実行するための関数
        //private void CalcProcessing()
        //{
        //    for (int i = 0; i < this.TemporaryCalcList.Count; i++)
        //    {
        //        // 呼び出した配列の値を変数へ
        //        String CalcStr = this.TemporaryCalcList[i];

        //        // 呼び出した配列の値が数字である場合
        //        if (int.TryParse(CalcStr, out int Number))
        //        {
        //            // 何番目の配列かを判定
        //            switch (i)
        //            {
        //                // はじめの配列である場合
        //                case 0:
        //                    // 数字を一時保存
        //                    this.TemporaryNumber = Number;
        //                    break;

        //                // 式の途中の数字である場合
        //                default:
        //                    // 計算を実行
        //                    int Temp = FormulaExecute(this.TemporarySymbol, this.TemporaryNumber, Number);

        //                    // 計算結果を一時保存
        //                    this.TemporaryNumber = Temp;

        //                    // 一時保存した計算記号をリセット
        //                    this.TemporarySymbol = null;

        //                    break;

        //            } // end switch.

        //        } // end for.
        //        else // 数字ではなく記号である場合
        //        {
        //            // 後の計算のために、計算記号を一時保存
        //            CheckSymbol(CalcStr);

        //        } // end if.
        //    } // end foreach.
        //} // end func CalcProcessing.


        // 計算を行う関数
        internal int FormulaExecute(int Number1, String CalcSymbol, int Number2 )
        {
            int Result = 0;

            switch ( CalcSymbol )
            {
                case "+":
                    Result = Number1 + Number2;
                    break;

                case "-":
                    Result = Number1 - Number2;
                    break;

                case "×":
                    Result = Number1 * Number2;
                    break;

                case "÷":
                    Result = Number1 / Number2;
                    break;

            }
            return Result;

        } // end func FormulaExecute.

    } // end partial class MainWindow : Window.

} // namespace calculator.
