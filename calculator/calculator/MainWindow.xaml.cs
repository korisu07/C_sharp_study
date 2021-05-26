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
using static System.Console;


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

            // 画面に反映
            ViewerTopWindow();
            ViewerBottomWindow();
        }

        protected const string ResultSymbol = "=";

        //
        // ★表示に関する設定
        //

        // 上段に表示する文字列
        protected String TopText = "";

        // 下段に表示する文字列
        protected String BottomText = "";


        //
        // ★内部処理に関する設定
        //

        // 数字の入力ケタが確定した際に、数字を格納する
        // 計算記号もここへ
        protected List<string> ListCalcProcess = new List<string>();


        // 現在入力されている数字をリアルタイムで更新する変数
        protected String RealtimeEnterNum = "0";

        // 一時的に入力された計算記号を保存しておく変数
        protected String EnteredCalcSymbols;


        //
        // ★ON/OFFを判別するための設定
        //

        // 以下は、trueであれば、ONになっている状態
        // 1つ前に数字が入力されていればON
        protected bool BoolEnteredNumber = false;

        // 1つ前に計算記号が入力されていればON
        protected bool BoolEnteredCalc = false;


        //
        // ★ボタンの表示切り替えのための設定
        // 

        // 括弧ボタンの表示切り替えを制御する
        // trueであれば、括弧ボタンが「)」に切り替わる
        protected bool BoolControlBracketsBtn = false;

        //
        // ★内部のデータに関する処理
        //

        // 入力された値をListに格納する処理
        // ★発動タイミング
        // 数字の場合：次の計算記号が入力された場合
        // 計算記号の場合：次の数字が入力された場合
        protected void AddBtnValueToList(String Str)
        {

            // Listを初期化
            var NewCalcList = new List<string>();

            // ボタンが入力されていない場合
            if (this.ListCalcProcess.Count == 0)
            {
                // 新たに入力されたボタンの値をListに追加
                NewCalcList.Add(Str);
            }// すでにボタンが入力されている場合 
            else
            {
                // まず、格納されている値をListに追加
                NewCalcList.AddRange(this.ListCalcProcess);
                // 新たに入力されたボタンの値を追加
                NewCalcList.Add(Str);
            }

            this.ListCalcProcess = NewCalcList;

        } // end method AddBtnValueToList.


        // 内部の値をリセットするための処理
        protected void ResetInternalData()
        {
            // 格納されている数字をリセット
            this.RealtimeEnterNum = null;
            this.EnteredCalcSymbols = null;

            // フラグをリセット
            this.BoolEnteredNumber = false;
            this.BoolEnteredCalc = false;
            this.BoolControlBracketsBtn = false;
        } // end func Reset.



        //
        // ★表示に関する処理
        //

        // 入力された数字や計算式を、画面上に表示する処理
        // AddStr → 後ろに追加する文字列を代入
        protected void ViewerTopWindow()
        {
            // 初期化
            this.TopText = null;

            // Listに値が格納されていれば発動
            if (this.ListCalcProcess != null)
            {
                // List内に登録されている値をつなげていき、一つの文字列にする
                foreach (String CalcStr in this.ListCalcProcess)
                {
                    String ViewStr = CalcStr + " ";
                    this.TopText += ViewStr;
                }
            }


        } // end method ViewEnteredBtn.

        protected void ViewerBottomWindow()
        {

            // 下段に入力中の数字を反映させる
            this.BottomText = this.RealtimeEnterNum;
        }

    }
}
