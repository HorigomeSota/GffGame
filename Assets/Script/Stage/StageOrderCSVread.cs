using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;

public class StageOrderCSVread : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(ReadCsv());
    }


    // CSVから切り分けられた文字列型配列データ 
    private string[] g_oredrDataArrays;
    /// <summary>
    /// ステージの順番、ファイル名取得
    /// </summary>
    /// <returns>ステージ順にファイル名が格納された配列</returns>
    public string[] GetStageOrderDatas()
    {
        return g_oredrDataArrays;
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
    /// CSVデータを文字列型配列に変換する
    /// </summary>
    /// <param name="path">ファイルパス</param>
    /// <param name="sdata">配列</param>
    private void readCSVData(string strStream, ref string[] sdata)
    {
        

        //改行を消去
        strStream = strStream.Replace("\r", "").Replace("\n", "");
        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;
        // カンマ分けの準備(区分けする文字を設定する)
        string[] spliter = strStream.Split(new char[1] { ',' }, option);

        // 列数設定
        int w = spliter.Length;

        // 返り値の配列の要素数を設定
        sdata = new string[w];



        // 行データを切り分けて,配列へ変換する
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
    IEnumerator ReadCsv()
    {
        string textFileName = "Order.csv";

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

        readCSVData(unityWebRequest.downloadHandler.text, ref this.g_oredrDataArrays);

        GetComponent<StageOrder>().SetStageOrder(g_oredrDataArrays);

        yield break;
    }
}
