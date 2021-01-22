using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    TimeData m_timedata;
    /// <summary>
    /// TimeDataが入っているオブジェクトのタグ名
    /// </summary>
    const string m_datatag = "Data";

    //　タイマー表示用テキスト
    private GameObject timerText;
    private int m_minutes;
    /// <summary>
    /// 秒数
    /// </summary>
    private int m_seconds;
    /// <summary>
    /// 小数点以下の秒数
    /// </summary>
    private int m_comma;


    private void Start()
    {
        //ゲームオブジェクトFind
        timerText = GameObject.FindGameObjectWithTag("TextTimer");
        m_timedata = GameObject.FindGameObjectWithTag(m_datatag).GetComponent<TimeData>();

    }


    /// <summary>
    /// GameManagerから呼び出されて時間を加算して表示する。※要ゲームオブジェクトへのアタッチ
    /// </summary>
    /// <param name="g_time"></param>
    public void TimerOutput()
    {
        float g_time = m_timedata.GetPlayNow();
        if (g_time != 0)
        {

            m_seconds = (int)(g_time - g_time % 1);
            if (m_seconds >= 60)
            {
                m_minutes = m_seconds / 60;
                m_seconds = m_seconds % 60;
            }
            m_comma = (int)(g_time % 1*100);

        }

        timerText.GetComponent<Text>().text =m_minutes.ToString("00")+":"+ m_seconds.ToString("00") + ":" + m_comma.ToString("00");
        return;
    }

    public int getSecond()
    {
        return m_seconds;
    }
    public int getComma()
    {
        return m_comma;
    }
}
