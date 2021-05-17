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
        private List ListCalcProcess;

        private int CalcResult;


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
            // 入力された数字を取得し、数字に変換
            String StrEnteredNumber = ((Button)sender).Content.ToString();
            int ClickNumber = int.Parse(StrEnteredNumber);

            

        }

        // 入力された値をListに格納する処理
        // 数字が入力された場合
        private static void AddBtnToList(int Number)
        {

        }

        // 計算記号が入力された場合
        private static void AddBtnToList(String Str)
        {

        }


        private void ConvertArray(String str, RoutedEventArgs e)
        {



        }
  

        // 入力された数字や計算式を、画面上に表示する処理
        private void ViewEnteredNumber()
        {
            //TopViewbox.Text = this.ViewerProcess;
            //BottomViewbox.Text = this.ViewerResult;
        }

        // 計算記号を入力した場合の処理
        private void ClickCalcSymbols(object sender, RoutedEventArgs e)
        {


        }

        private void ResultCalc(object sender, RoutedEventArgs e)
        {




        }

    }
}
