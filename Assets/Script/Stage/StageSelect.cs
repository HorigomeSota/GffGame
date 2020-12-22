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
        string m_stageNameTop=default;


        //エンドレスまでのステージ数を取得
        while (m_stageNameTop != "E")
        {
            m_a++;
            m_stageNameTop = m_stageName[m_a].Substring(0, 1);
            print(m_a + "こここお");
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
            
            if(i==m_a)
            {
                listButton.transform.Find("StageName").GetComponent<Text>().text = "∞ENDLESS∞";
            }
            listButton.transform.GetComponent<StageSelectButton>().SetStageNumber(i+1);

            //読み込んだステージ数に応じて横の長さを伸ばす(ここのXの値は要調整)
            listRectTrs.sizeDelta = new Vector2(listRectTrs.sizeDelta.x+370 , listRectTrs.sizeDelta.y);
            m_timeData.LoadPlayerData();//データ読み込み

            float g_bestTime = m_timeData.GetBestTime(i);
            float g_secondTime = m_timeData.GetSecondTime(i);
            float g_thirdTime = m_timeData.GetThirdTime(i);
            int m_bestMinutes=default;
            int m_secondMinutes=default;
            int m_thirdMinutes=default;
            int m_bestSeconds = (int)(g_bestTime - g_bestTime % 1);
            int m_secondSeconds = (int)(g_secondTime - g_secondTime % 1);
            int m_thirdSeconds = (int)(g_thirdTime - g_thirdTime % 1);
            int m_bestComma = default;
            int m_secondComma = default;
            int m_thirdComma = default;
            if (g_bestTime == 9999)
            {
                m_bestMinutes = 99;
                m_bestSeconds = 99;
                m_bestComma = 99;
            }
            else
            if (m_bestSeconds >= 60)
            {
                m_bestMinutes = m_bestSeconds / 60;
                m_bestSeconds = m_bestSeconds % 60;
                m_bestComma = (int)(g_bestTime % 1 * 100);
            }

            if (g_secondTime == 9999) 
            {
                m_secondMinutes = 99;
                m_secondSeconds = 99;
                m_secondComma = 99;
            }
            else
            if (m_secondSeconds >= 60)
            {
                m_secondMinutes = m_bestSeconds / 60;
                m_secondSeconds = m_bestSeconds % 60;
                m_secondComma = (int)(g_secondTime % 1 * 100);
            }

            if (g_thirdTime == 9999)
            {
                m_thirdMinutes = 99;
                m_thirdSeconds = 99;
                m_thirdComma = 99;
            }
            else
            if (m_thirdSeconds >= 60)
            {
                m_thirdMinutes = m_bestSeconds / 60;
                m_thirdSeconds = m_bestSeconds % 60;
                m_thirdComma = (int)(g_thirdTime % 1 * 100);
            }
            

            listButton.transform.Find("BestScore").GetComponent<Text>().text= m_bestMinutes.ToString("00") + ":" + m_bestSeconds.ToString("00") + ":" + m_bestComma.ToString("00");
            listButton.transform.Find("SecondScore").GetComponent<Text>().text= m_secondMinutes.ToString("00") + ":" + m_secondSeconds.ToString("00") + ":" + m_secondComma.ToString("00");
            listButton.transform.Find("ThirdScore").GetComponent<Text>().text= m_thirdMinutes.ToString("00") + ":" + m_thirdSeconds.ToString("00") + ":" + m_thirdComma.ToString("00");
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