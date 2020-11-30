﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Timer格納用の変数。インスタンス化済み
    /// </summary>
    Timer m_tim = new Timer();

    /// <summary>
    /// AudioManager格納用変数
    /// </summary>
    AudioManager m_audioManager;

    /// <summary>
    /// PlayerState格納用変数
    /// </summary>
    PlayerState m_playerState;

    /// <summary>
    /// Input格納用変数
    /// </summary>
    IInput m_input=new SmartPhoneInput();

    /// <summary>
    /// UIManager格納用変数
    /// </summary>
    UIManager m_UIManager;

    /// <summary>
    /// UIManagerが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_UIManagerObject;

    /// <summary>
    /// AudioManagerが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_audioManagerObject;

    /*
    /// <summary>
    /// timerが入ってるオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_timerObject;
    */

    /// <summary>
    /// PlayerStateが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_playerStateObject;



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
    /// オーディオが再生中かどうか
    /// </summary>
    private bool m_playAudio;

    /// <summary>
    /// 時間
    /// </summary>
    private float m_time=0;

    private void Awake()
    {
        //インスタンス化
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_playerState = m_playerStateObject.GetComponent<PlayerState>();
        m_UIManager = m_UIManagerObject.GetComponent<UIManager>();

        //if(スマートフォンなら)
        m_input = new SmartPhoneInput();


    }

    private void Start()
    {
        GameStart();
    }

    /// <summary>
    /// 時間を計ってTimerに時間の加算を頼む、送られた時間をUIManagerへ
    /// </summary>
    void Update()
    {
        if (m_gamestarting)
        {


            //Inputのジャンプ呼び出し
            m_jumpinput= m_input.JumpCheck();

            //Inputのカラーチェンジ呼び出し
            m_colorcheckinput = m_input.ColorCheck();


            if (m_playerState.GetJumpFlag())
            {
                m_audioManager.JumpSE();
            }
            else if (m_playerState.GetBoostFlag())
            {
                m_audioManager.BoostSE();
            }
            else if (m_playerState.GetColorChangeFlag())
            {
                m_audioManager.ColorChangeSE();
            }
            else if (m_playerState.GetPanelSpeedUpFlag())
            {
                m_audioManager.PanelSE();
            }
            else if (m_playerState.GetDeathFlag())
            {

            }
            else
            {
                //m_playAudio = false;
            }



            //ジャンプとカラーチェンジの条件判定
            if (m_jumpinput)
            {
                m_playerState.JumpFlagOn();
                //Debug.Log("ジャンプ");
                m_jumpinput = false;
                
            }
            if (m_colorcheckinput)
            {
                m_playerState.ColorChangeFlagOn();
                m_colorcheckinput = false;
            }
            //リセット
            m_input.Reset();


            //タイマーカウント呼び出し
            m_time = m_tim.TimerCount(Time.deltaTime);

            //UIManagerでタイマー表示
            m_UIManager.TimerOutput(m_time);
        }

        if (m_playerState.GetDeathFlag() == true) GameEnd();
    }

    /// <summary>
    /// ゲームのスタート
    /// </summary>
    private void GameStart()
    {
        m_gamestarting = true;
        m_audioManager.StageBGM();
        m_tim.TimerStart();

    }

    /// <summary>
    /// ゲームの終わり
    /// </summary>
    public void GameEnd()
    {
        m_gamestarting = false;
    }

}
