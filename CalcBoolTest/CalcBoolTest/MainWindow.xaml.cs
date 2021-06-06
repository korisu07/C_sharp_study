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

namespace CalcBoolTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CopyForBoolTest : Window
    {

        // 以下は、trueであれば、ONになっている状態
        // 1つ前に数字が入力されていればON
        protected bool BoolEnteredNumber = false;

        // 1つ前に計算記号が入力されていればON
        protected bool BoolEnteredCalc = false;


        // 配列に括弧が含まれており
        // 以降の値が括弧内の式であることを判定するためのBool値
        private bool BoolEnclosedInBrackets = false;


        // 括弧の終わりが入力されたことを示し、
        // カッコ内の式を処理しはじめるためのBool値
        private bool BoolEndBrackets = false;

        private List<string> TestList = new List<string>();

        public CopyForBoolTest()
        {
            InitializeComponent();
        }

        public void TestBtnNumber(object sender, RoutedEventArgs e)
        {
            // ボタンの内容を取得し、
            string BtnContent = ((Button)sender).Content.ToString();

            TestChangeBoolNumber(BtnContent);
        }

        public void TestBtnCymbol(object sender, RoutedEventArgs e)
        {
            string BtnContent = ((Button)sender).Content.ToString();

            TestChangeBoolCymbol(BtnContent);
        }

        public void TestBtnBrackets(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("括弧が入力されました！");
        }

        public void TestChangeBoolNumber(string str)
        {
            // 計算記号がすでに登録されている場合
            if (this.BoolEnteredCalc)
            {
                MessageBox.Show("計算記号の後に数字を入力します...");

                // フラグをリセット
                this.BoolEnteredCalc = false;
            }


            // 数字が登録されているフラグをON
            this.BoolEnteredNumber = true;

            MessageBox.Show("数字が登録されました！");

        }

        public void TestChangeBoolCymbol(string str)
        {
            // すでに数字か計算記号が入力されている場合
            if (this.BoolEnteredNumber || this.BoolEnteredCalc)
            {
                // 計算式が登録されていなければ、先に入力されていた数値を登録
                if (this.BoolEnteredCalc == false)
                {
                    MessageBox.Show("計算記号の入力準備中...");

                    // フラグをリセット
                    this.BoolEnteredNumber = false;
                } // 先に計算記号が登録されており、それを変更したい場合
                else if (this.BoolEnteredNumber == false)
                {
                    MessageBox.Show("計算記号を変更します...");

                }

                // 計算記号が登録されているフラグをON
                this.BoolEnteredCalc = true;

                MessageBox.Show("計算記号が登録されました！");
            }
            else
            {
                MessageBox.Show("なにも起きない状態です...");
            }
        }
    }
}
