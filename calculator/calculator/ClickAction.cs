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
using static calculator.MainWindow;


namespace calculator
{
    public partial class ClickAction : MainWindow
    {
        
        //
        // ★ボタンに関する処理
        //

        // 押したボタンに設定されている数字を取得して、
        // 数字ボタンが入力された場合の処理
        protected new void ClickNumberAction(object sender, RoutedEventArgs e)
        {
            // 計算記号がすでに登録されている場合
            if (base.BoolEnteredCalc)
            {
                // 格納していた値をリセット
                base.RealtimeEnterNum = null;
                // 下段の値をリセット
                base.BottomText = null;

                // 計算記号をリセット
                base.EnteredCalcSymbols = null;
                // フラグをリセット
                base.BoolEnteredCalc = false;
            }

            // 新たに入力された数字を取得し、文字列に変換
            String ClickBtnNumber = ((Button)sender).Content.ToString();

            // 入力済みの数字＋新たに入力された数字をくっつける
            int FormatNumber = int.Parse(base.RealtimeEnterNum + ClickBtnNumber);
            base.RealtimeEnterNum = FormatNumber.ToString();

            // 画面に反映
            base.ViewerTopWindow();
            base.ViewerBottomWindow();

            // 数字が登録されているフラグをON
            base.BoolEnteredNumber = true;

        } // end method ClickNumberAction.


        // 計算記号が入力された場合の処理
        protected new void ClickCalcSymbols(object sender, RoutedEventArgs e)
        {
            // 計算記号を初期化
            base.EnteredCalcSymbols = null;

            // すでに数字か計算記号が入力されている場合
            if (base.BoolEnteredNumber || base.BoolEnteredCalc)
            {
                // 計算式が登録されていなければ、先に入力されていた数値を登録
                if (base.BoolEnteredCalc == false)
                {
                    // 数字をリストに追加
                    base.AddBtnValueToList(base.RealtimeEnterNum);

                    // フラグをリセット
                    base.BoolEnteredNumber = false;
                } // 先に計算記号が登録されており、それを変更したい場合
                else if (base.BoolEnteredNumber == false)
                {

                    // 変更したい記号はリストの最後尾に登録されているため、
                    // 一番うしろのリストを参照し、それを削除する
                    int ListCount = base.ListCalcProcess.Count - 1;

                    base.ListCalcProcess.RemoveAt(ListCount);
                }

                // 新たに入力されたボタンを取得し、文字列に変換
                String Symbols = ((Button)sender).Content.ToString();
                // 計算記号を、変数へ格納する
                base.EnteredCalcSymbols = Symbols;

                // 計算記号をリストに追加
                base.AddBtnValueToList(base.EnteredCalcSymbols);

                // 画面に反映
                base.ViewerTopWindow();
                base.ViewerBottomWindow();

                // 計算記号が登録されているフラグをON
                base.BoolEnteredCalc = true;

            } //なにも入力されていない場合
            else
            {
                // なにもしない
                return;
            }

        } // end method ClickCalcSymbols.

        // 括弧ボタンをクリックした場合の処理
        private new void ClickBrackets(object sender, RoutedEventArgs e)
        {
            // 括弧の登録状況で分岐

            // 括弧の先頭が登録されておらず、
            // かつ直前の入力が記号である場合
            if (base.BoolControlBracketsBtn == false && base.BoolEnteredCalc)
            {
                // 新たに入力されたボタンを取得し、文字列に変換
                String ClickBtnbrackets = ((Button)sender).Content.ToString();
                // 括弧をリストに追加
                base.AddBtnValueToList(ClickBtnbrackets);


                // 括弧が登録されたフラグをONにする
                base.BoolControlBracketsBtn = true;

                // ボタンの表示を切り替え
                ((Button)sender).Content = ")";

            }
            // すでに先頭の括弧が登録されていて
            // かつ、直前の登録が数字である場合
            else if (base.BoolControlBracketsBtn && base.BoolEnteredNumber)
            {
                // 直前に入力されていた数字をリストに追加
                base.AddBtnValueToList(base.RealtimeEnterNum);
                // リセット
                base.RealtimeEnterNum = null;

                // 新たに入力されたボタンを取得し、文字列に変換
                String ClickBtnbrackets = ((Button)sender).Content.ToString();
                // 括弧をリストに追加
                base.AddBtnValueToList(ClickBtnbrackets);


                // 括弧が登録されたフラグをOFFにする
                base.BoolControlBracketsBtn = false;

                // ボタンの表示を切り替え
                ((Button)sender).Content = "(";

            } // end if and else.


            // 画面に反映
            base.ViewerTopWindow();
            base.ViewerBottomWindow();

        } // end method ClickBrackets.


        // 「=」ボタンを押した場合の処理
        private new void ResultCalc(object sender, RoutedEventArgs e)
        {
            var Logic = new LogicCalc();

            // 数字が入力中の状態である場合のみ発動
            if (base.BoolEnteredNumber)
            {
                // 数字をリストに追加
                base.AddBtnValueToList(base.RealtimeEnterNum);

            } //end if, Bool is ON.


            // 計算式が成立していれば発動
            if (base.ListCalcProcess.Count >= 3)
            {
                // = をリストに追加
                base.AddBtnValueToList(ResultSymbol);

                // まずは、括弧があるかどうかを判定し、
                // ふりわける
                foreach (String CalcStr in base.ListCalcProcess)
                {
                    Logic.BracketsCalc(CalcStr);
                } // end foreach.

                // ふりわけが終わった最終の計算式を処理
                Logic.LastCalc();

                String Result = Logic.TemporaryNumber.ToString();

                base.AddBtnValueToList(Result);
                base.BottomText = Result;


                // 画面に反映
                base.ViewerTopWindow();
                base.ViewerBottomWindow();

                // 内部の値をリセット
                base.ResetInternalData();

            }
            else // 条件を満たさない場合
            {
                // なにもしない
                return;
            }
        } // end method ResultCalc.


        // ACボタンを押したときの処理
        private new void ResetAll(object sender, RoutedEventArgs e)
        {
            // 内部のデータをリセット
            ResetInternalData();

            // リストを削除
            base.ListCalcProcess.Clear();
            // リストを再度初期化
            base.ListCalcProcess = new List<string>();

            // 画面に表示するデータも初期化
            base.TopText = null;
            base.BottomText = null;

            // 画面に反映
            base.ViewerTopWindow();
            base.ViewerBottomWindow();

        } // end method ResetAll.

    }
}
