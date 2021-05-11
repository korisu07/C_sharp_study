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

        private String CalcProcess;

        private String CalcResult;


        // 押したボタンに設定されている数字を取得して、
        // 数字を入力するための処理
        private void Button_Click_Number(object sender, RoutedEventArgs e)
        {
            // 入力された数字を取得
            String ClickNumber = ((Button)sender).Content.ToString();

            // 元々入力されていた数字や計算式と連結させる
            this.CalcProcess = this.CalcProcess + ClickNumber;
            this.CalcResult = this.CalcResult + ClickNumber;

            // 入力された値を表示する
            this.ViewEnteredNumber();

        }

        // 入力された数字や計算式を、画面上に表示する処理
        private void ViewEnteredNumber()
        {
            TopViewbox.Text = this.CalcProcess;
            BottomViewbox.Text = this.CalcResult;
        }

    }
}
