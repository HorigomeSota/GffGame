using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Timer格納用の変数。インスタンス化済み
    /// </summary>
    Timer tim = new Timer();

    /// <summary>
    /// UIManagerが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject UIManagerObject;

    /// <summary>
    /// ゲームがスタートするとTRUEになる
    /// </summary>
    private bool gamestarting = false;

    /// <summary>
    /// 時間
    /// </summary>]
    private float m_time=0;

    /// <summary>
    /// 時間を計ってTimerに時間の加算を頼む、送られた時間をUIManagerへ
    /// </summary>
    void Update()
    {
        if (gamestarting)
        {
            m_time=tim.TimerCount(Time.deltaTime);
            UIManagerObject.GetComponent<UIManager>().TimerOutput(m_time);
        }
    }
    /// <summary>
    /// ゲームのスタート
    /// </summary>
    public void GameStart()
    {
        gamestarting = true;
        tim.TimerStart();
    }
    /// <summary>
    /// ゲームの終わり
    /// </summary>
    public void GameEnd()
    {
        gamestarting = false;
    }

}
