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

            string hantei;
            hantei = textBox1.Text;
            hantei = hantei.Replace("\r", "").Replace("\n", "");

            //判定結果がfalseだった場合
            if (IsNumeric(textBox1.Text) == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("三桁の数字を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (hantei.Length == 3)
            {
                // 文字コードを指定
                Encoding enc = Encoding.GetEncoding("Shift_JIS");

                // ファイルを開く

                // ファイルパスの変数
                string filepath = "D:\\git\\atarukun\\atarukun\\DB\\TousenNumber.txt";
      

                // 文字コードを指定してファイルを開く
                StreamReader sr = new StreamReader(filepath, Encoding.GetEncoding("Shift_JIS"));

                //文字を読み込む
                string Tousen = sr.ReadToEnd();

                Tousen = Tousen.Replace("\r", "").Replace("\n", "");

                //ファイルを閉じる
                sr.Close();

                //変数Tousenのもっとも古い数値以外を抜き出す
                Tousen = Tousen.Substring(4);

                //変数Tousenにテキストボックスの内容を書き加える
                Tousen = Tousen + "," + textBox1.Text; 

                //ファイルを開く
                StreamWriter writer = new StreamWriter(filepath, false, enc);

                // テキストを書き込む
                writer.WriteLine(Tousen);

                // ファイルを閉じる
                writer.Close();

                //メッセージボックスを表示
                MessageBox.Show("登録しました",
                   "登録完了",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.None);
            }

            else
            {
                //メッセージボックスを表示する
                MessageBox.Show("三桁の数字を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }



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

        //テキストボックス内の入力値が数字かどうか判定するメソッド
        public static bool IsNumeric(string stTarget)
        {
            double dNullable;

            return double.TryParse(
                stTarget,
                System.Globalization.NumberStyles.Any,
                null,
                out dNullable
            );
        }
    }
    

}
