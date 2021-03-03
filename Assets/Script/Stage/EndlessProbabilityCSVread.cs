using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;

public class EndlessProbabilityCSVread : MonoBehaviour
{

    //エンドレスモードの確率の配列
    private int[,] g_probabilityDatas;

    private void Awake()
    {
        StartCoroutine(ReadCsv());
    }


    /// <summary>
    /// エンドレスモードの確率の配列の取得
    /// </summary>
    /// <returns>確率の2次元配列</returns>
    public int[,] GetProbabilityDatas()
    {
        return g_probabilityDatas;
    }

    // CSVから切り分けられた文字列型２次元配列データ 
    private string[,] g_probabilityDataArrays;

    //行数
    private int g_height = 0;
    /// <summary>
    /// 行数取得
    /// </summary>
    /// <returns>行数</returns>
    public int GetHeight()
    {
        return g_height;
    }
    //列数
    private int g_width = 0;
    /// <summary>
    /// 列数取得
    /// </summary>
    /// <returns>列数</returns>
    public int GetWidth()
    {
        return g_width;
    }

    /// <summary>
    /// CSVデータを文字列型２次元配列に変換する
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <param name="sdata">2次元配列（文字型）</param>
    private void readCSVData(string strStream, ref string[,] sdata)
    {


       
        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        // 行に分ける
        string[] lines = strStream.Split(new char[] { '\r', '\n' }, option);

        // カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        // 行数設定
        int h = lines.Length;
        // 列数設定
        int w = lines[0].Split(spliter, option).Length;

        // 返り値の2次元配列の要素数を設定
        sdata = new string[h, w];

        // 行データを切り分けて,2次元配列へ変換する
        for (int i = 0; i < h; i++)
        {
            string[] splitedData = lines[i].Split(spliter, option);

            for (int j = 0; j < w; j++)
            {
                sdata[i, j] = splitedData[j];
            }
        }

        // 確認表示用の変数(行数、列数)を格納する
        this.g_height = h;
        this.g_width = w;
    }

    /// <summary>
    /// ２次元配列の型を文字列型から整数値型へ変換する
    /// </summary>
    /// <param name="sarrays">文字型の配列</param>
    /// <param name="iarrays">整数値型の配列</param>
    /// <param name="h">高さ</param>
    /// <param name="w">長さ</param>
    private void convert2DArrayType(ref string[,] sarrays, ref int[,] iarrays, int h, int w)
    {
        iarrays = new int[h, w];
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                iarrays[i, j] = int.Parse(sarrays[i, j]);
            }
        }


        GetComponent<StageOrder>().SetEndlessProbability(iarrays);
    }

    
   

    /// <summary>
    /// CSV読み込んで準備
    /// </summary>
    IEnumerator ReadCsv()
    {
        string textFileName = "EndlessProbability.csv";

        string path = null;

        DeviceType deviceType;

        deviceType = SystemInfo.deviceType;


        if (deviceType == DeviceType.Desktop)
        {
            path = Application.dataPath + "/StreamingAssets" + "/" + textFileName;
        }
        else if (deviceType == DeviceType.Handheld)
        {

            path = "jar:file://" + Application.dataPath + "!/assets" + "/" + textFileName;
        }
        UnityWebRequest unityWebRequest;

        unityWebRequest = UnityWebRequest.Get(path);

        yield return unityWebRequest.SendWebRequest();

        readCSVData(unityWebRequest.downloadHandler.text, ref this.g_probabilityDataArrays);
        convert2DArrayType(ref this.g_probabilityDataArrays, ref this.g_probabilityDatas, this.g_height, this.g_width);

        yield break;
    }
}
