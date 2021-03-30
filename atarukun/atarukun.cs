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
        public string ikkun(string yagi_value)
        {
            //いっくんをいれる箱
            string ikkun_value1;

            //いっくんと八木君をくっつける
            ikkun_value1 = "いっくん" + "と" + yagi_value;

            //値を戻す
            return ikkun_value1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //八木くんを入れる箱
            string yagi_value;

            //結果を入れる箱
            string result;

            //八木君を入れる
            yagi_value = "八木くん";

            //いっくんメソッドを呼び出す
            result = ikkun(yagi_value);

            //テキストボックスに値をいれる
            textBox1.Text = result;

        }
    }
}
