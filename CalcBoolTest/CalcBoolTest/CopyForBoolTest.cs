using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalcBoolTest
{
    // テスト用ライブラリが機能しないため、
    // 判定式のテストを行うために、処理をコピーしました
    class CopyForBoolTest : MainWindow
    {
        // 配列に括弧が含まれており
        // 以降の値が括弧内の式であることを判定するためのBool値
        private bool BoolEnclosedInBrackets = false;

        // 括弧の終わりが入力されたことを示し、
        // カッコ内の式を処理しはじめるためのBool値
        private bool BoolEndBrackets = false;

        private List<string> TestList = new List<string>();

        public void TestBool()
        {
            
        }
    }
}
