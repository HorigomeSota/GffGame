using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    /// <summary>
    /// GameManagerから呼び出されて時間を加算して表示する。※要ゲームオブジェクトへのアタッチ
    /// </summary>
    /// <param name="time"></param>
    public void TimerOutput(float time)
    {
        if (time != 0)
        {
            seconds = (int)(time - time % 1);
            comma = (int)(time % 1*100);
        }

        timerText.GetComponent<Text>().text = seconds + ":" + comma;
        return;
    }
}
