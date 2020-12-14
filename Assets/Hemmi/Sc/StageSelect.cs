using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class StageSelect : MonoBehaviour
{
    public GameObject listButtonPrefab;
    GameObject list;
    StageOrder m_stageOrder;

    TimeData m_timeData;
    int n;

    [SerializeField]
    string[] m_stageName=new string[10];

    /// <summary>
    /// ステージセレクト画面に行く前に呼び出す
    /// </summary>
    private void Start()
    {
        m_stageOrder = GameObject.Find("StageCreate").GetComponent<StageOrder>();
        m_stageName=m_stageOrder.GetStageOrder();
        int m_a = 0;
        string m_stageNameTop = m_stageName[m_a].Substring(0,1);


        //エンドレスまでのステージ数を取得
        while (m_stageNameTop != "E")
        {
            m_a++;
            Debug.Log(m_a + "m_a");
            m_stageNameTop = m_stageName[m_a].Substring(0, 1);
            Debug.Log(m_stageNameTop);
        }
        m_timeData = GameObject.FindGameObjectWithTag("Data").transform.GetComponent<TimeData>();
        list = GameObject.Find("List");
        Transform listTrs = list.transform;
        RectTransform listRectTrs = list.transform.GetComponent<RectTransform>();
        for (int i = 0; i <= m_a; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(listButtonPrefab) as GameObject;
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(listTrs, false);

            //Stage表示(エンドレスはエンドレスと表示する
            if (i!=m_a)
            {
                listButton.transform.Find("StageName").GetComponent<Text>().text = "STAGE" + (i + 1).ToString();
            }
            else
            {
                listButton.transform.Find("StageName").GetComponent<Text>().text = "∞ENDLESS∞";
            }
            listButton.transform.GetComponent<StageSelectButton>().SetStageNumber(i+1);

            //読み込んだステージ数に応じて横の長さを伸ばす
            listRectTrs.sizeDelta = new Vector2(listRectTrs.sizeDelta.x+300 , listRectTrs.sizeDelta.y);
            m_timeData.LoadPlayerData();//データ読み込み

            float g_time = m_timeData.GetBestScore();
            int m_minutes=default;
            int m_seconds = (int)(g_time - g_time % 1);
            if (m_seconds >= 60)
            {
                m_minutes = m_seconds / 60;
                m_seconds = m_seconds % 60;
            }
            int m_comma = (int)(g_time % 1 * 100);


            listButton.transform.Find("BestScore").GetComponent<Text>().text= m_minutes.ToString("00") + ":" + m_seconds.ToString("00") + ":" + m_comma.ToString("00");
            listButton.transform.Find("SecondScore").GetComponent<Text>().text= m_minutes.ToString("00") + ":" + m_seconds.ToString("00") + ":" + m_comma.ToString("00");
            listButton.transform.Find("ThirdScore").GetComponent<Text>().text= m_minutes.ToString("00") + ":" + m_seconds.ToString("00") + ":" + m_comma.ToString("00");
            //以下、追加---------
            n = i;
        }
    }
    
    /*
    void MyOnClick(int index)
    {
        print(index);
    }
    */
}