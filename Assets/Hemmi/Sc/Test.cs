using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Test : MonoBehaviour
{
    public GameObject listButtonPrefab;
    GameObject list;

    TimeData m_timeData;
    int n;
    void Start()
    {
        m_timeData = GameObject.FindGameObjectWithTag("Data").transform.GetComponent<TimeData>();
        list = GameObject.Find("List");
        Transform listTrs = list.transform;
        for (int i = 0; i < 5; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(listButtonPrefab) as GameObject;
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(listTrs, false);
            if (i != 4)
            {
                listButton.transform.Find("StageName").GetComponent<Text>().text = "STAGE" + (i + 1).ToString();
            }
            else
            {
                listButton.transform.Find("StageName").GetComponent<Text>().text = "∞ENDLESS∞";
            }

            listButton.transform.GetComponent<StageSelecteButton>().SetStageNumber(i+1);
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
            //以下、追加---------
            n = i;
            //引数に何番目のボタンかを渡す
            //
            //listButton.GetComponent<Button>().onClick.AddListener(() => MyOnClick(n));
        }
    }
    
    /*
    void MyOnClick(int index)
    {
        print(index);
    }
    */
}