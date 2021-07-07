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

        //抽選ボタン押下時のメソッド
        private void button1_Click(object sender, EventArgs e)
        {

            //結果を格納する変数
            string result;

            //抽選ボタンクラスのインスタンスを生成
            atarukun.Chuusen.Chuusen ch = new atarukun.Chuusen.Chuusen();

            //結果を格納
            result = ch.Chuusen_Click();

            //テキストボックスに値を表示
            textBox1.Text = result;
            textBox2.Text = result;
            textBox3.Text = result;
        }

        //登録画面へ押下時のメソッド
        private void button3_Click(object sender, EventArgs e)
        {
            atarukun.Touroku.Touroku ataru = new atarukun.Touroku.Touroku();
            ataru.Show();
            this.Hide();
        }

        //閉じるボタン押下時のメソッド
        private void button2_Click(object sender, EventArgs e)
        {
            //フォームを閉じる
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
