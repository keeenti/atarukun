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

            string TousenKai;
            string Tousendate;
            string TousenBangou;

            //抽選回のテキストボックスを取得
            TousenKai = textBox1.Text;
            TousenKai = TousenKai.Replace("\r", "").Replace("\n", "");

            //抽選年月日のテキストボックスを取得
            Tousendate = textBox2.Text;
            Tousendate = Tousendate.Replace("\r", "").Replace("\n", "");

            //当選番号のテキストボックスを取得
            TousenBangou = textBox3.Text;
            TousenBangou = TousenBangou.Replace("\r", "").Replace("\n", "");

            //抽選回の判定結果がfalseだった場合
            if (IsNumeric(textBox1.Text) == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("四桁の数字を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            //抽選年月日の判定結果がfalseだった場合
            if (IsDate(textBox2.Text) == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("「yyyy/mm/dd」の形式で入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            //当選番号の判定結果がfalseだった場合
            if (IsNumeric(textBox3.Text) == false)
            {
                //メッセージボックスを表示する
                MessageBox.Show("三桁の数字を入力してください。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (TousenBangou.Length == 3 & TousenKai.Length == 4)
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

                //改行コードを空白に置き換える
                //Tousen = Tousen.Replace("\r", "").Replace("\n", "");

                //ファイルを閉じる
                sr.Close();

                //変数Tousenのもっとも古い数値以外を抜き出す
               //Tousen = Tousen.Substring(4);

                //変数Tousenにテキストボックスの値を書き加える
                Tousen = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + Environment.NewLine + Tousen; 

                //ファイルを開く
                StreamWriter writer = new StreamWriter(filepath, false, enc);

                // テキストを書き込む
                writer.Write(Tousen);

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
                MessageBox.Show("正しい値を入力してください。",
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

            //抽選回にTousenNumber.txtの内容を呼び出す
            textBox1.Text = str.Substring(0, 4); 

            //抽選年月日にTousenNumber.txtの内容を呼び出す
            textBox2.Text = str.Substring(5, 10);

            //当選番号にTousenNumber.txtの内容を呼び出す
            textBox3.Text = str.Substring(16, 3);

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

        //当選年月日が適正かどうか判定するメソッド
        public static bool IsDate(string stDate)
        {
            try
            {
                //西暦の変数
                string DateHantei1;
                //月の変数
                string DateHantei2;
                //日の変数
                string DateHantei3;
                //日付区切りに"/"の変数
                string DateSlashHantei1;
                string DateSlashHantei2;

                //西暦の切り出し
                DateHantei1 = stDate.Substring(0, 4);
                //月の切り出し
                DateHantei2 = stDate.Substring(5, 2);
                //日の切り出し
                DateHantei3 = stDate.Substring(8, 2);
                //日付区切りの"/"の切り出し
                DateSlashHantei1 = stDate.Substring(4, 1);
                DateSlashHantei2 = stDate.Substring(7, 1);

                if (stDate.Length != 10)
                {
                    return false;
                }
                else if (DateSlashHantei1 != "/" | DateSlashHantei2 != "/")
                {
                    return false;

                }
                else if (DateHantei1.Length != 4 | DateHantei2.Length != 2 | DateHantei3.Length != 2)
                {
                    return false;
                }
                else if (IsNumeric(DateHantei1) == false | IsNumeric(DateHantei2) == false | IsNumeric(DateHantei3) == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ArgumentOutOfRangeException) 
            {
                MessageBox.Show("例外が発生しました。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
              }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //フォームを閉じる
            this.Close();

            //atarukun画面を開く
            WindowsFormsApp1.Form1 fo = new WindowsFormsApp1.Form1();
            fo.Visible = true;
        }

        private void Touroku_Load(object sender, EventArgs e)
        {
            
        }
    }
    

}
