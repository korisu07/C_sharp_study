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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 計算の過程を表示する
        private String ViewerProcess;

        // 現在、入力されている最中の数字、
        // または計算結果の数字を表示する
        private String ViewerResult;

        // 数字の入力ケタが確定した際に、数字を格納する
        // 計算記号もここへ
        private Array CalcProcess;

        private int CalcResult;

        private String[] ArrayCalcProcess;


        // すでに計算記号が入力されているかを判別する
        // trueであれば、入力されている状態
        private bool BoolEnteredSymbols = false;

        // 先頭の括弧がすでに入力されているかを判別する
        // trueであれば、入力されている状態
        private bool BoolEnteredbrackets = false;


        // 押したボタンに設定されている数字を取得して、
        // 数字を入力するための処理
        private void Button_Click_Number(object sender, RoutedEventArgs e)
        {
            // 計算記号が入力されているフラグをリセット
            this.BoolEnteredSymbols = false;


            // 入力された数字を取得し、数字に変換
            String StrEnteredNumber = ((Button)sender).Content.ToString();
            int ClickNumber = int.Parse( StrEnteredNumber );

            // 元々入力されていた数字や計算式と連結させる
            this.ViewerProcess = this.ViewerProcess + ClickNumber;
            this.ViewerResult = this.ViewerResult + ClickNumber;

            // 入力された値を表示する
            this.ViewEnteredNumber();

        }

        private void ConvertArray(String str, RoutedEventArgs e)
        {



        }
  

        // 入力された数字や計算式を、画面上に表示する処理
        private void ViewEnteredNumber()
        {
            TopViewbox.Text = this.ViewerProcess;
            BottomViewbox.Text = this.ViewerResult;
        }

        // 計算記号を入力した場合の処理
        private void ClickCalcSymbols(object sender, RoutedEventArgs e)
        {
            // 入力された計算式のシンボルを取得し、
            // 前後に半角スペースを追加
            String ClickSymbols = " " + ((Button)sender).Content.ToString() + " ";

            // 記号が未入力の場合
            if( this.BoolEnteredSymbols == false)
            {
                this.BoolEnteredSymbols = true;

                // 元々入力されていた数字や計算式と連結させる
                this.ViewerProcess = this.ViewerProcess + ClickSymbols;
            } else
            {
                
            }


            // 入力された値を表示する
            this.ViewEnteredNumber();

            // 表示し配列に格納後、前回入力されていた数字をリセット
            this.ViewerResult = null;

        }

        private void ResultCalc(object sender, RoutedEventArgs e)
        {

            Double d;

             String testStr = "+";

             if( Double.TryParse(testStr, out d) )
             {
                 Double.TryParse(testStr, out d);
                 MessageBox.Show(d.ToString());
             } else
             {
                 MessageBox.Show(testStr);
             }


        }

    }
}
