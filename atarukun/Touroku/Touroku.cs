using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atarukun.Touroku
{
    public partial class Touroku : Form
    {
        public Touroku()
        {
            InitializeComponent();
        }

        //登録ボタン押下時のメソッド
        private void button1_Click(object sender, EventArgs e)
        {

            // 変数
            string filepath = "D:\\git\\atarukun\\atarukun\\DB\\TousenNumber.txt";

            // 文字コードを指定
            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            // ファイルを開く
            StreamWriter writer = new StreamWriter(filepath, false, enc);

            // テキストを書き込む
            writer.WriteLine(textBox1.Text);

            // ファイルを閉じる
            writer.Close();

            //メッセージボックスを表示
            MessageBox.Show("登録しました",
               "登録完了",
               MessageBoxButtons.OK,
               MessageBoxIcon.None);
        }

        //昨日の当選番号を確認ボタン押下時のメソッド
        private void button3_Click(object sender, EventArgs e)
        {
            // 変数
            string filepath = "D:\\git\\atarukun\\atarukun\\DB\\TousenNumber.txt";


            // 文字コードを指定してファイルを開く
            StreamReader sr = new StreamReader(filepath, Encoding.GetEncoding("Shift_JIS"));

            //文字を読み込む
            string str = sr.ReadToEnd();

            //テキストボックスにTousenNumber.txtの内容を呼び出す
            textBox1.Text = str;

            //ファイルを閉じる
            sr.Close();

            Console.WriteLine(str);

            //メッセージボックスを表示
            MessageBox.Show("昨日の当選番号を呼び出しました",
               "呼び出し完了",
               MessageBoxButtons.OK,
               MessageBoxIcon.None);

        }
    }
}
