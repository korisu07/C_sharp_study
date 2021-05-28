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
        internal int TemporaryNumber = 0;

        private String TemporarySymbol;

        private List<String> TemporaryCalcList = new List<String>();

        private List<String> BracksTemporaryCalcList = new List<String>();

        // 配列に括弧が含まれており
        // 以降の値が括弧内の式であることを判定するためのBool値
        private bool BoolEnclosedInBrackets = false;

        // 括弧の終わりが入力されたことを示し、
        // カッコ内の式を処理しはじめるためのBool値
        private bool BoolEndBrackets = false;

        internal void BracketsCalc(String CalcStr)
        {
            SwitchBrackets( CalcStr );
            AllocateValue( CalcStr );

        }// end method BracketsCalc.

        internal void LastCalc()
        {
            CalcProcessing( this.TemporaryCalcList );

        }// end method LastCalc.

        // スイッチの状態によって、括弧があるかどうかを判断し、
        // 現在が括弧内の式であるならば先に計算を行う
        private void AllocateValue(String CalcStr)
        {
            // 先頭の括弧が登録されており、かつまだ中身の計算が途中である場合
            if( this.BoolEnclosedInBrackets )
            {
                this.BracksTemporaryCalcList.Add(CalcStr);
            } // 後尾の括弧が登録されており、括弧内の計算がまだ処理されていない場合
            else if ( this.BoolEndBrackets )
            {
                CalcProcessing(this.BracksTemporaryCalcList);

                // 計算がすべて終わったら、最終計算用のリストに結果を格納する
                this.TemporaryCalcList.Add( this.TemporaryNumber.ToString() );

                // リセット
                this.TemporaryNumber = 0;
                // フラグを解除
                this.BoolEndBrackets = false;

            } else // 括弧が関係ない場合
            {
                // 最終計算用のリストに値を格納する
                this.TemporaryCalcList.Add(CalcStr);
            }
        }// end method AllocateValue.


        // 括弧が登録されているかどうかを判断するための関数
        private void SwitchBrackets( String CalcStr )
        {
            // 括弧かどうかを判定
            switch ( CalcStr )
            {
                // はじめ括弧である場合
                case "(":

                    //フラグをON
                    this.BoolEnclosedInBrackets = true;
                    break;

                // おわり括弧である場合
                case ")":

                    // フラグをOFF
                    this.BoolEnclosedInBrackets = false;
                    // 括弧の終わりが入力されたフラグをONにする
                    this.BoolEndBrackets = true;
                    break;


                // 数字や計算記号である場合
                default:
                    // なにもしない
                    break;
                       
            } // end switch.

        } // end func SwitchBracket.


        // 値を振り分け、計算を実行するための関数
        private void CalcProcessing(List<string> CalcList)
        {
            foreach (String CalcStr in CalcList)
            {

                // 呼び出した配列の値が数字である場合
                if (int.TryParse(CalcStr, out int Number))
                {
                    // 計算を実行
                    FormulaExecute( Number );

                }
                else // 数字ではなく記号である場合
                {
                    // 後の計算のために、計算記号を一時保存
                    this.TemporarySymbol = CalcStr;

                } // end if.
            }

        } // end func CalcProcessing.


        // 事前に保存されている数値と、新しく入力された数値の計算を行う処理
        private void FormulaExecute(int Number)
        {

            switch ( this.TemporarySymbol )
            {
                case "+":
                    this.TemporaryNumber += Number;
                    break;

                case "-":
                    this.TemporaryNumber -= Number;
                    break;

                case "×":
                    this.TemporaryNumber *= Number;
                    break;

                case "÷":
                    this.TemporaryNumber /= Number;
                    break;

                default:
                    this.TemporaryNumber = Number;
                    break;

            }

            // 計算が完了した後に、一時保存した計算記号をリセット
            this.TemporarySymbol = null;


        } // end func FormulaExecute.

    } // end partial class MainWindow : Window.

} // namespace calculator.
