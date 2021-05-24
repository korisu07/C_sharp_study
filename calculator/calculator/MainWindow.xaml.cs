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
            // 画面に数字を表示
            ViewEnteredBtn();
        }

        private const string ResultSymbol = " = ";

        //
        // ★表示に関する設定
        //

        // 上段に表示する文字列
        private String ViewerTop = "";

        // 下段に表示する文字列
        private String ViewerBottom = "";


        //
        // ★内部処理に関する設定
        //

        // 数字の入力ケタが確定した際に、数字を格納する
        // 計算記号もここへ
        public List<string> ListCalcProcess = new List<string>();


        // 現在入力されている数字をリアルタイムで更新する変数
        private String RealtimeEnterNum = "0";

        // 一時的に入力された計算記号を保存しておく変数
        private String EnteredCalcSymbols;


        //
        // ★ON/OFFを判別するための設定
        //

        // 以下は、trueであれば、入力されている状態
        // 数字が入力されているかを判別する
        private bool BoolEnteredNumber = false;

        // 計算式が入力されているかを判別する
        private bool BoolEnteredCalc = false;

        // 先頭の括弧がすでに入力されているかを判別する
        private bool BoolEnteredBrackets = false;


        //
        // ★表示に関する処理
        //

        // 入力された数字や計算式を、画面上に表示する処理
        // AddStr → 後ろに追加する文字列を代入
        private void ViewEnteredBtn()
        {
            // 初期化
            this.ViewerTop = null;

            // Listに値が格納されていれば発動
            if(this.ListCalcProcess != null)
            {
                // List内に登録されている値をつなげていき、一つの文字列にする
                foreach(String CalcStr in this.ListCalcProcess)
                {
                    String ViewStr = CalcStr + " ";
                    this.ViewerTop += ViewStr;
                }
            }

            // 下段に入力中の数字を反映させる
            this.ViewerBottom = this.RealtimeEnterNum;

            // 上段と下段にそれぞれ反映
            TopViewbox.Text = this.ViewerTop;
            BottomViewbox.Text = this.ViewerBottom;

        } // end method ViewEnteredBtn.

        //
        // ★内部のデータに関する処理
        //

        // 入力された値をListに格納する処理
        // ★発動タイミング
        // 数字の場合：次の計算記号が入力された場合
        // 計算記号の場合：次の数字が入力された場合
        private void AddBtnValueToList(String Str)
        {

            // Listを初期化
            var NewCalcList = new List<string>();

            // ボタンが入力されていない場合
            if( this.ListCalcProcess.Count == 0)
            {
                // 新たに入力されたボタンの値をListに追加
                NewCalcList.Add(Str);
            }// すでにボタンが入力されている場合 
            else
            {
                // まず、格納されている値をListに追加
                NewCalcList.AddRange(this.ListCalcProcess);
                // 新たに入力されたボタンの値を追加
                NewCalcList.Add( Str );
            }

            this.ListCalcProcess = NewCalcList;

        } // end method AddBtnValueToList.


        //
        // ★ボタンに関する処理
        //

        // 押したボタンに設定されている数字を取得して、
        // 数字ボタンが入力された場合の処理
        private void ClickNumberAction(object sender, RoutedEventArgs e)
        {
            // 計算記号がすでに登録されている場合
            if (this.BoolEnteredCalc)
            {
                // 格納していた値をリセット
                this.RealtimeEnterNum = null;
                // 下段の値をリセット
                this.ViewerBottom = null;

                // 計算記号をリセット
                this.EnteredCalcSymbols = null;
                // フラグをリセット
                this.BoolEnteredCalc = false;
            }

            // 新たに入力された数字を取得し、文字列に変換
            String ClickBtnNumber = ((Button)sender).Content.ToString();

            // 入力済みの数字＋新たに入力された数字をくっつける
            int FormatNumber = int.Parse(this.RealtimeEnterNum + ClickBtnNumber);
            this.RealtimeEnterNum = FormatNumber.ToString();

            // 画面に反映
            ViewEnteredBtn();
            // 数字が登録されているフラグをON
            this.BoolEnteredNumber = true;

        } // end method ClickNumberAction.


        // 計算記号が入力された場合の処理
        private void ClickCalcSymbols(object sender, RoutedEventArgs e)
        {
            // 計算記号を初期化
            this.EnteredCalcSymbols = null;

            // すでに数字か計算記号が入力されている場合
            if (this.BoolEnteredNumber || this.BoolEnteredCalc)
            {
                // 計算式が登録されていなければ、先に入力されていた数値を登録
                if (this.BoolEnteredCalc == false)
                {
                    // 数字をリストに追加
                    AddBtnValueToList(this.RealtimeEnterNum);

                    // フラグをリセット
                    this.BoolEnteredNumber = false;
                } // 先に計算記号が登録されており、それを変更したい場合
                else if (this.BoolEnteredNumber == false) {

                    // 変更したい記号はリストの最後尾に登録されているため、
                    // 一番うしろのリストを参照し、それを削除する
                    int ListCount = this.ListCalcProcess.Count - 1;

                    this.ListCalcProcess.RemoveAt( ListCount );
                }

                // 新たに入力されたボタンを取得し、文字列に変換
                String Symbols = ((Button)sender).Content.ToString();
                // 計算記号を、変数へ格納する
                this.EnteredCalcSymbols = Symbols;

                // 計算記号をリストに追加
                AddBtnValueToList( this.EnteredCalcSymbols );

                // 画面に反映
                ViewEnteredBtn();
                // 計算記号が登録されているフラグをON
                this.BoolEnteredCalc = true;

            } //なにも入力されていない場合
            else
            {
                // なにもしない
                return;
            }

        } // end method ClickCalcSymbols.

        // 括弧ボタンをクリックした場合の処理
        private void ClickBrackets(object sender, RoutedEventArgs e)
        {
            // 新たに入力されたボタンを取得し、文字列に変換
            String ClickBtnbrackets = ((Button)sender).Content.ToString();

            // 括弧をリストに追加
            AddBtnValueToList(ClickBtnbrackets);


            // 括弧の登録状況で分岐
            // 括弧の先頭が登録されていない場合
            if (this.BoolEnteredBrackets == false)
            {
                // 括弧が登録されたフラグをONにする
                this.BoolEnteredBrackets = true;

                // ボタンの表示を切り替え
                ((Button)sender).Content = ")";

            }
            else
            { //すでに先頭の括弧が登録されている場合

                // 括弧が登録されたフラグをOFFにする
                this.BoolEnteredBrackets = false;

                // ボタンの表示を切り替え
                ((Button)sender).Content = "(";

            } // end if and else.

        } // end method ClickBrackets.


        // 「=」ボタンを押した場合の処理
        private void ResultCalc(object sender, RoutedEventArgs e)
        {
            var Logic = new LogicCalc();

            // 数字が入力中の状態である場合のみ発動
            if (this.BoolEnteredNumber)
            {
                // 数字をリストに追加
                AddBtnValueToList(this.RealtimeEnterNum);

            } //end if, Bool is ON.

            Logic.TemporaryCalcList.AddRange( this.ListCalcProcess );


            // 計算式が成立していれば発動
            if ( this.ListCalcProcess.Count >= 3 )
            {
                // = をリストに追加
                AddBtnValueToList( ResultSymbol );

                Logic.LastCalc();

                String Result = Logic.TemporaryNumber.ToString();

                AddBtnValueToList( Result );
                this.ViewerBottom = Result;

                // 画面に反映
                ViewEnteredBtn();
                // 内部の値をリセット
                ResetInternalData();

            } else // 条件を満たさない場合
            {
                // なにもしない
                return;
            }
        } // end method ResultCalc.


        // 内部の値をリセットするための処理
        private void ResetInternalData()
        {
            // 格納されている数字をリセット
            this.RealtimeEnterNum = null;
            this.EnteredCalcSymbols = null;

            // フラグをリセット
            this.BoolEnteredNumber = false;
            this.BoolEnteredCalc = false;
            this.BoolEnteredBrackets = false;
        } // end func Reset.

        // ACボタンを押したときの処理
        private void ResetAll(object sender, RoutedEventArgs e)
        {
            // 内部のデータをリセット
            ResetInternalData();

            // リストを削除
            this.ListCalcProcess.Clear();
            // リストを再度初期化
            this.ListCalcProcess = new List<string>();

            // 画面に表示するデータも初期化
            this.ViewerTop = null;
            this.ViewerBottom = null;

            // 画面に反映
            ViewEnteredBtn();

        } // end method ResetAll.

    }
}
