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
        public int Onetimes = 0;
        public int Twotimes = 0;
        public int Threetimes = 0;
        public int Fourtimes = 0;

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
            string[] nChuusen = new string[130];
            string[] nGoukei = new string[130];
            string[] nTousen = new string[5];

            //テキストから最近の当選番号5つを取得し配列に格納
            nChuusen = Get_ChuusenNumber(Select_number);
            nGoukei = Get_GoukeiNumber(Select_number);
            //想定される数字を配列に格納
            nTousen = Get_OldNumber(text_value);
            int nGoukeiBySum = 0;

            //最近の当選番号を想定される数字から削除
            for (int i = 0; i < nTousen.Length; i++)
            {
                string arrvalue = nChuusen[i];
                //想定される数字分ループ
                for (int j = 0; j < nChuusen.Length; j++)
                {
                    nGoukeiBySum = Int32.Parse(nGoukei[j]);
                    string arrvalue2 = nTousen[j];
                    //3桁に分けるための配列の定義
                    int[] Keta2 = new int[3];
                    //配列に3桁の値を格納
                    Keta2[0] = Int32.Parse(arrvalue2.Substring(0, 1));
                    Keta2[1] = Int32.Parse(arrvalue2.Substring(1, 1));
                    Keta2[2] = Int32.Parse(arrvalue2.Substring(2, 1));
                    //3桁の和を格納
                    int nGoukeiBySum2 = Keta2.Sum();
                    //合計の番号を比較
                    if (nGoukeiBySum == nGoukeiBySum2)
                    {
                        switch (nGoukeiBySum)
                        {
                            case 5: 
                                break;   
                            case 6: 
                                break;  
                            case 7: 
                                break;  
                            case 8: 
                                break;  
                            case 19: 
                                break;  
                            case 20: 
                                break;  
                            case 21:
                                break; 
                            case 22: 
                                break;  
                            default:
                                Get_GoukeiRemove(nGoukeiBySum,nChuusen,nGoukei);


                             break; 
                        }

                        if (arrvalue == arrvalue2)
                        {
                            arrvalue2.Remove(j);
                        }

                    }
                }
            }
                //配列からカンマ区切りで値を取得
                string strSeparator = ",";

                // 文字列の配列を指定した文字列を付け加えて連結する
                Number_result = string.Join(strSeparator, nChuusen);

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
            public string[] Get_OldNumber(string num)
            {
                string tousennum;
                string resultnum = "";
                string[] resultnum2 = new string[100];

                //引数numの中身を、改行コードをカンマに変換してtousennnumに代入する
                tousennum = num.Replace("\r", ",").Replace("\n", "");
                //配列変数linesに、変数tousennumの中身をカンマ区切りで代入する
                string[] lines = tousennum.Split(',');
                //配列の中から三桁数字のものを抽出する
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Length == 3)
                    {
                        resultnum = resultnum + lines[i];
                    }
                }
                resultnum = String.Format("{0:#,0}", int.Parse(resultnum));
                resultnum2 = resultnum.Split(',');
                return resultnum2;
            }
            //予め絞り込んだ抽選番号を取得
            public string[] Get_ChuusenNumber(string num)
            {
                string tousennum;
                string resultnum = "";
                string[] resultnum2 = new string[200];

                //引数numの中身を、改行コードをカンマに変換してtousennnumに代入する
                tousennum = num.Replace("\r", ",").Replace("\n", "");
                //配列変数linesに、変数tousennumの中身をカンマ区切りで代入する
                string[] lines = tousennum.Split(',');
                //配列の中から三桁数字のものを抽出する
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Length == 3)
                    {
                        resultnum = resultnum + lines[i];
                    }
                }
                resultnum = String.Format("{0:#,0}", int.Parse(resultnum));
                resultnum2 = resultnum.Split(',');
                return resultnum2;
            }
            //予め絞り込んだ抽選番号の和を取得
            public string[] Get_GoukeiNumber(string num)
            {
                string tousennum;
                string resultnum = "";
                string[] resultnum2 = new string[200];

                //引数numの中身を、改行コードをカンマに変換してtousennnumに代入する
                tousennum = num.Replace("\r", ",").Replace("\n", "");
                //配列変数linesに、変数tousennumの中身をカンマ区切りで代入する
                string[] lines = tousennum.Split(',');
                //配列の中から三桁数字のものを抽出する
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Length == 1 || lines[i].Length == 2)
                    {
                        resultnum = resultnum + lines[i];
                    }
                }
                resultnum = String.Format("{0:#,0}", int.Parse(resultnum));
                resultnum2 = resultnum.Split(',');
                return resultnum2;
            }
            public string[] Get_GoukeiRemove(int num,string[] nChuusens)
            {
                for (int i = 0; i < nChuusens.Length; i++)
                {
                    if (num == nChuusens[i])
                    {

                    }

                }

            }

    }
}
