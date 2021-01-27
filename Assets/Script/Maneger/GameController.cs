using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject m_titleRootObj=default;
    [SerializeField] private GameObject m_GameRootObj=default;
    [SerializeField] private GameObject m_StageRootObj=default;
    [SerializeField] private GameObject m_inputObj=default;
    [SerializeField] private GameObject m_stageCreate = default;

    private GameObject m_gameManager;
    /// <summary>
    /// 0
    /// </summary>
    const int m_titleSceneNum = 0;
    /// <summary>
    /// 1
    /// </summary>
    const int m_stageSerectSceneNum = 1;
    /// <summary>
    /// 2
    /// </summary>
    const int m_gameSceneNum = 2;
    /// <summary>
    /// 3
    /// </summary>
    const int m_retryNum = 3;
    /// <summary>
    /// 4
    /// </summary>
    const int m_escapeNum = 4;

    /// <summary>1フレーム前に取得した値 </summary>
    private int m_beforeNum=0; //初期化

    IInput m_input;

    private void Start()
    {
      
        m_GameRootObj.SetActive(false);

        m_StageRootObj.SetActive(false);

        m_input = m_inputObj.GetComponent<IInput>();

    }
    private void Update()
    {
       
        switch (m_input.SceneCheck())
        {
            case m_titleSceneNum:

                if (m_titleSceneNum!=m_beforeNum)
                {
                    TitleObjOn();
                    m_beforeNum = m_titleSceneNum;
                }
                

                break;

            case m_stageSerectSceneNum:

                if (m_stageSerectSceneNum != m_beforeNum)
                {
                    StageObjOn();
                    m_beforeNum = m_stageSerectSceneNum;
                }
               

                break;

            case m_gameSceneNum:

                if ( m_gameSceneNum != m_beforeNum)
                {
                    print(m_input);

                    m_stageCreate.GetComponent<StageOrder>().SetFirstStage(m_input.ChoiceObj().GetComponent<StageSelectButton>().GetStageNumber());

                    m_stageCreate.GetComponent<StageMapCSVread>().MapCsvRead(m_stageCreate.GetComponent<StageOrder>().GetNextStage());

                    m_beforeNum = m_gameSceneNum;

                }

                if (m_stageCreate.GetComponent<StageMapCSVread>().GetReadEndFlag() == true)
                {
                    m_stageCreate.GetComponent<StageMapCSVread>().ReadEndFlagOff();
                    GameObjOn();
                }

                break;

            case m_retryNum:

                if (m_retryNum != m_beforeNum)
                {
                    Retry();
                    m_beforeNum = m_retryNum;
                }
                break;

            case m_escapeNum:
                if (m_escapeNum != m_beforeNum)
                {
                    Escape();
                    m_beforeNum = m_escapeNum;
                }
                break;
                

        }
        
    }

    

    private void GameObjOn()
    {
       

        m_titleRootObj.SetActive(false);

        m_StageRootObj.SetActive(false);

        m_GameRootObj.SetActive(true);

        m_gameManager = GameObject.FindGameObjectWithTag("GameManager");

        m_gameManager.GetComponent<GameManager>().GameStart();



    }
    private void TitleObjOn()
    {
        m_GameRootObj.SetActive(false);

        m_StageRootObj.SetActive(false);

        m_titleRootObj.SetActive(true);
    }
    private void StageObjOn()
    {
        m_titleRootObj.SetActive(false);

        m_GameRootObj.SetActive(false);

        m_StageRootObj.SetActive(true);
    }

    private void Retry()
    {

    }

    private void Escape()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
