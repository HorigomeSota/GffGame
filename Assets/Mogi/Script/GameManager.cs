using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Timer格納用の変数。インスタンス化済み
    /// </summary>
    Timer m_tim;

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
    IInput m_input;

    /// <summary>
    /// UIManager格納用変数
    /// </summary>
    UIManager m_UIManager;

    /// <summary>
    /// Timer格納オブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_TimerObject;

    /// <summary>
    /// UIManagerとInputが入っているゲームオブジェクト(canvas
    /// </summary>
    [SerializeField]
    GameObject m_CanvasObject;

    /// <summary>
    /// AudioManagerが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_audioManagerObject;


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


    private void Awake()
    {
        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        m_playerStateObject = GameObject.FindGameObjectWithTag("Player");
        m_CanvasObject = GameObject.FindGameObjectWithTag("Canvas");
        m_TimerObject=GameObject.FindGameObjectWithTag("Timer");

        //インスタンス化
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_playerState = m_playerStateObject.GetComponent<PlayerState>();
        m_UIManager = m_CanvasObject.GetComponent<UIManager>();
        m_input = m_CanvasObject.GetComponent<IInput>();
        m_tim = m_TimerObject.GetComponent<Timer>();


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



            //ジャンプとカラーチェンジの条件判定
            if (m_jumpinput)
            {
                m_playerState.JumpFlagOn();
                Debug.Log("ジャンプ");
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
            m_tim.TimerCount(Time.deltaTime);

            //UIManagerでタイマー表示
            m_UIManager.TimerOutput();
        }

        if (m_playerState.GetDeathFlag() == true) GameEnd();
    }

    /// <summary>
    /// ゲームのスタート
    /// </summary>
    private void GameStart()
    {
        m_gamestarting = true;
        m_audioManager.PlayClip("stage1");
        m_tim.TimerReset();
    }

    /// <summary>
    /// ゲームの終わり
    /// </summary>
    public void GameEnd()
    {
        m_gamestarting = false;
    }

}
