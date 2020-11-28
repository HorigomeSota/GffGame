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
    GameObject m_UIManagerObject;

    /// <summary>
    /// Inputが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_InputObject;

    /// <summary>
    /// PlayerStateが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_PlayreState;

    /// <summary>
    /// ゲームがスタートするとTRUEになる
    /// </summary>
    [SerializeField] private bool m_gamestarting = false;
    /// <summary>
    /// JumpCheckのリターン
    /// </summary>
    private bool m_jumpinput = false;
    /// <summary>
    /// ColorCheckのリターン
    /// </summary>
    private bool m_colorcheckinput = false;
    /// <summary>
    /// 時間
    /// </summary>]
    private float m_time=0;





    /// <summary>
    /// 時間を計ってTimerに時間の加算を頼む、送られた時間をUIManagerへ
    /// </summary>
    void Update()
    {
        if (m_gamestarting)
        {


            //Inputのジャンプ呼び出し
            m_jumpinput= m_InputObject.GetComponent<IInput>().JumpCheck();

            //Inputのカラーチェンジ呼び出し
            m_colorcheckinput = m_InputObject.GetComponent<IInput>().ColorCheck();

            //ジャンプとカラーチェンジの条件判定
            if (m_jumpinput)
            {
                m_PlayreState.GetComponent<PlayerState>().JumpFlagOn();
                Debug.Log("ジャンプ");
                m_jumpinput = false;
            }
            if (m_colorcheckinput)
            {
                Debug.Log("最初に呼ばれてますけど何か");
                m_PlayreState.GetComponent<PlayerState>().ColorChangeFlagOn();
                m_colorcheckinput = false;
            }
            //リセット
            m_InputObject.GetComponent<IInput>().Reset();


            //タイマーカウント呼び出し
            m_time =tim.TimerCount(Time.deltaTime);

            //UIManagerでタイマー表示
            m_UIManagerObject.GetComponent<UIManager>().TimerOutput(m_time);
        }

        if (m_PlayreState.GetComponent<PlayerState>().GetDeathFlag() == true) GameEnd();
    }




    /// <summary>
    /// ゲームのスタート
    /// </summary>
    public void GameStart()
    {
        m_gamestarting = true;
        tim.TimerStart();
    }




    /// <summary>
    /// ゲームの終わり
    /// </summary>
    public void GameEnd()
    {
        m_gamestarting = false;
    }

}
