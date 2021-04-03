using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        //いっくんメソッド
        public string[] ikkun()
        {
            //いっくんをいれる箱(配列バージョン)
            string[] ikkun_value1 = new string[3];

            ikkun_value1[0] = "いっくん1";
            ikkun_value1[1] = "いっくん2";
            ikkun_value1[2] = "いっくん3";

            //文字列をくっつける
            //ikkun_value1 = yagi_value;

            //値を戻す
            return ikkun_value1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //八木くんを入れる箱
            //string yagi_value; 

            //結果を入れる箱
            string[] result;

            //八木君を入れる
            //yagi_value = "八木くん";

            //いっくんメソッドを呼び出す
            result = ikkun();

            foreach (string item in result)
            {
                textBox1.Text = textBox1.Text + item;
            }

            //テキストボックスに値をいれる
            //textBox1.Text = result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            atarukun.Touroku.Touroku ataru = new atarukun.Touroku.Touroku();
            ataru.Show();


        }
    }
}
