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
    [SerializeField]
    GameObject timerText;
    /// <summary>
    /// 秒数
    /// </summary>
    private int seconds;
    /// <summary>
    /// 小数点以下の秒数
    /// </summary>
    private int comma;


    private void Start()
    {
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
            seconds = (int)(g_time - g_time % 1);
            comma = (int)(g_time % 1*100);
        }

        timerText.GetComponent<Text>().text = seconds + ":" + comma;
        return;
    }
}
