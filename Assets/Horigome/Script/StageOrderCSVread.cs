using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class StageOrderCSVread : MonoBehaviour
{
    // CSVから切り分けられた文字列型２次元配列データ 
    private string[] g_oredrDataArrays;
    public string[] GetStageOrderDatas()
    {
        return g_oredrDataArrays;
    }

    //読み込めたか確認の表示用の変数
    private int g_width = 0;    //列数
    public int GetWidth()
    {
        return g_width;
    }

    // CSVデータを文字列型２次元配列に変換する
    //                      ファイルパス,変換される配列の値(参照渡し)
    private void readCSVData(string path, ref string[] sdata)
    {
        // ストリームリーダーsrに読み込む
        StreamReader sr = new StreamReader(path);
        // ストリームリーダーをstringに変換
        string strStream = sr.ReadToEnd();
        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;
        // カンマ分けの準備(区分けする文字を設定する)
        string[] spliter = strStream.Split(new char[1] { ',' }, option);

        // 列数設定
        int w = spliter.Length;

        // 返り値の配列の要素数を設定
        sdata = new string[w];

        // 行データを切り分けて,2次元配列へ変換する
        for (int j = 0; j < w; j++)
        {
            sdata[j] = spliter[j];
        }

        // 確認表示用の変数(行数、列数)を格納する
        this.g_width = w;    //列数
    }

    /// <summary>
    /// CSV読み込んで準備
    /// </summary>
    public string[] PrepareStageOrder()
    {
        readCSVData(Application.dataPath + "/StreamingAssets/stages/Order.csv", ref this.g_oredrDataArrays);
        return g_oredrDataArrays;
    }


    //確認表示用の関数
    //引数：2次元配列データ,行数,列数
    private void WriteMapOrderDatas(string[] arrays, int wid)
    {
        for (int j = 0; j < wid; j++)
        {
            //行番号-列番号:データ値 と表示される
            Debug.Log(j + ":" + arrays[j]);
        }
    }
}
