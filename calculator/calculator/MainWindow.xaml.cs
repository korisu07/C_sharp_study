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

        // 押したボタンに設定されているNameの値を取得して、
        // 数字だけを取り出し、値を返す関数
        private void Button_Click_Number(object sender, RoutedEventArgs e)
        {
            String Str = ((Button)sender).Name;
            String NewStr = Str.Replace("btn", "");
            MessageBox.Show( NewStr );
        }

    }
}
