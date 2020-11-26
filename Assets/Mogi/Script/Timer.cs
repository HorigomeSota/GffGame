using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Timer : MonoBehaviour
{
    /// <summary>
    /// 数字を表示するテキスト
    /// </summary>
    private Text timerText;


    /// <summary>
    /// 秒数
    /// </summary>
    private float m_time;


    /// <summary>
    /// タイマーの初期化
    /// </summary>
    public void TimerStart()
    {
        m_time = 0;
    }


    /// <summary>
    /// GameManagerから呼び出される、秒数を加算して返す
    /// </summary>
    public float TimerCount(float delta)
    {
        m_time += delta;
        return m_time;
    }
}
