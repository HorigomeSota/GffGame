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
    ///チェックポイントオブジェクト格納 
    /// </summary>
    private GameObject checkPoint = default;

    /// <summary>
    /// playerのオブジェクト
    /// </summary>
    private GameObject playerObj = default;

    /// <summary>
    /// Timer格納オブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_TimerObject;

    /// <summary>
    /// UIManagerが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_CanvasObject;

    /// <summary>
    /// Inputが入っているゲームオブジェクト
    /// </summary>
    [SerializeField]
    GameObject m_inputObj;

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

    private bool deathOnce = default;

    /// <summary>
    /// オーディオが再生中かどうか
    /// </summary>
    private bool m_playAudio;

    private bool timerStop=true;

    /// <summary>
    /// タイマースクリプト
    /// </summary>
    private TimeData m_timeData;

    private Vector3 startPosition = new Vector3(0f, 25f, -0.4f);

    private float startPositionX = default;

    private float startPositionY = default;

    private PlayerColorChange playerColorChange = default;

    private void Awake()
    {
        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        m_playerStateObject = GameObject.FindGameObjectWithTag("Player");
        m_CanvasObject = GameObject.FindGameObjectWithTag("GameCanvas");
        m_inputObj=GameObject.FindGameObjectWithTag("Input");
        m_TimerObject =GameObject.FindGameObjectWithTag("Timer");
        playerObj= GameObject.FindGameObjectWithTag("Player");
        playerColorChange = playerObj.GetComponent<PlayerColorChange>();

        //インスタンス化
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_playerState = m_playerStateObject.GetComponent<PlayerState>();
        m_UIManager = m_CanvasObject.GetComponent<UIManager>();
        m_input = m_inputObj.GetComponent<IInput>();
        m_tim = m_TimerObject.GetComponent<Timer>();
        m_timeData = GameObject.FindGameObjectWithTag("Data").transform.GetComponent<TimeData>();
    }

    private void Start()
    {
        startPositionX = -15f;
        startPositionY = 2f;
    }

    /// <summary>
    /// 時間を計ってTimerに時間の加算を頼む、送られた時間をUIManagerへ
    /// </summary>
    void Update()
    {
        if (m_gamestarting)
        {
            //Inputのジャンプ呼び出し
            m_jumpinput = m_input.JumpCheck();

            //Inputのカラーチェンジ呼び出し
            m_colorcheckinput = m_input.ColorCheck();

            //ジャンプとカラーチェンジの条件判定
            if (m_jumpinput)
            {
                m_playerState.JumpFlagOn();

                m_jumpinput = false;

            }
            if (m_colorcheckinput)
            {
                m_playerState.ColorChangeFlagOn();
                m_colorcheckinput = false;
            }
            //リセット
            m_input.Reset();

            if (!timerStop)
            {
                //タイマーカウント呼び出し
                m_tim.TimerCount(Time.deltaTime);
                //UIManagerでタイマー表示
                m_UIManager.TimerOutput();
            }

        }

        if (m_playerState.GetDeathFlag() == true&& !deathOnce)
        {
            GameEnd();
            playerColorChange.ResetColor();
            deathOnce = true;
        }
    }

    /// <summary>
    /// ゲームのスタート
    /// </summary>
    public void GameStart()
    {
        m_gamestarting = true;
        deathOnce = false;
        m_playerState.SetGameStart();
        GameObject.Find("StageCreate").GetComponent<CheckPointDistance>().StartCreate(startPosition);
        SetCheckPoint(playerObj);

    }

    /// <summary>
    /// ゲームの終わり
    /// </summary>
    public void GameEnd()
    {
        m_gamestarting = false;
    }

    public void SetCheckPoint(GameObject startObj)
    {
        checkPoint = startObj;
    }

    public void PlayerReset()
    {
        deathOnce = false;
        playerObj.GetComponent<SpriteRenderer>().enabled = true;
        Vector3 checkPointVec3 = checkPoint.transform.position;
        startPosition = new Vector3 (checkPointVec3.x+startPositionX, checkPointVec3.y+ startPositionY, checkPointVec3.z);
        m_gamestarting = true;
        m_playerState.SetGameStart();
        GameObject.Find("StageCreate").GetComponent<CheckPointDistance>().ReStart(startPosition);
        SetTimeStop(true);
        m_UIManager.ResetTimer();
    }

    public void SetTimeStop(bool Stop)
    {
        timerStop = Stop;
    }
}
