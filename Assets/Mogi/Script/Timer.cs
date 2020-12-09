using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Timer : MonoBehaviour
{
    TimeData m_timedata;
    /// <summary>
    /// TimeDataが入っているオブジェクトのタグ名
    /// </summary>
    const string m_datatag = "Data";
    /// <summary>
    /// 数字を表示するテキスト
    /// </summary>
    private Text timerText;

    /// <summary>
    /// プレイ中か判断するためのもの
    /// </summary>
    bool m_playnow;


    /// <summary>
    /// 秒数
    /// </summary>
    private float m_time;
    private void Start()
    {
        m_timedata = GameObject.FindGameObjectWithTag(m_datatag).GetComponent<TimeData>();
    }
    /// <summary>
    /// タイマーの初期化
    /// </summary>
    public void TimerReset()
    {
        m_time = 0;
    }

    /// <summary>
    /// GameManagerから呼び出される、秒数を加算して返す
    /// </summary>
    public void TimerCount(float delta)
    {
        m_time = delta;
        m_timedata.PlayNowTimeSave(m_time);
    }
}
