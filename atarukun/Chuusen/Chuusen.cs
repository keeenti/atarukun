using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atarukun.Chuusen
{
    //抽選結果クラス
    class Chuusen
    {
        //抽選ボタン押下時のメソッド
        public string Chuusen_Click()
        {
            //抽選結果を格納する変数
            string Chuusen_result;

            //仮
            Chuusen_result = Number_Select();

            //抽選結果を戻り値として返却する
            return Chuusen_result;

        }

        //ナンバーズ3の数字を絞り込む
        public string Number_Select()
        {
            //変数
            string Number_result;
            string text_value;
            string Select_number;

            string filePath = "D:\\git\\atarukun\\atarukun\\DB\\TousenNumber.txt";

            //テキストから値を取得
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));

                text_value = sr.ReadToEnd();

                sr.Close();
            }
            else
            {
                MessageBox.Show("前回の当選番号のファイルが存在しません");
                text_value = "";
            }

            //想定される数字を取得（事前に調査していた数字）
            Select_number = Get_Number();

            //想定される数字を配列に格納
            string[] arr = new string[130];
            string[] arr2 = new string[5];
            for (int i = 0; i < text_value.Length; i++)
            {
                arr2[i] = Select_number[i].ToString();

                for (int j = 0; j < Select_number.Length; i++)
                {

                    //テキストから取得した値の場合は格納しない
                    if (arr2[i] != Select_number[j].ToString())
                    {
                        arr[i] = Select_number[j].ToString();
                    }
                }
            }

            //配列からカンマ区切りで値を取得
            string strSeparator = ",";                        
            
            // 文字列の配列を指定した文字列を付け加えて連結する
            Number_result = string.Join(strSeparator, arr);

            //絞り込み結果
            return Number_result;

        }

        //想定される数字を取得するメソッド
        public string Get_Number()
        {
            string Select_number;

            string filePath2 = "D:\\git\\atarukun\\atarukun\\Chuusen\\Select_Number.txt";
            //テキストから値を取得
            if (File.Exists(filePath2))
            {
                StreamReader sr = new StreamReader(filePath2, Encoding.GetEncoding("Shift_JIS"));

                Select_number = sr.ReadToEnd();

                sr.Close();
            }
            else
            {
                MessageBox.Show("想定される数字が存在しません");
                Select_number = "";
            }

            return Select_number;

        }


    }
}
