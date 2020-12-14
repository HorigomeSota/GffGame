using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject m_titleRootObj;
    private GameObject m_GameRootObj;
    private GameObject m_StageRootObj;
    private GameObject m_CanvasObject;

    private GameObject m_gameManager;

    IInput m_input;

    private void Start()
    {
        m_titleRootObj = GameObject.FindWithTag("TitleRoot");
        m_GameRootObj = GameObject.FindWithTag("GameRoot");
        m_StageRootObj = GameObject.FindWithTag("StageRoot");
        m_CanvasObject=GameObject.FindGameObjectWithTag("Canvas");

        m_GameRootObj.SetActive(false);

        m_StageRootObj.SetActive(false);

        m_input = m_CanvasObject.GetComponent<IInput>();

    }
    private void Update()
    {

        switch (m_input.SceneCheck())
        {
            case 0:

                TitleObjOn();

                break;

            case 1:

                StageObjOn();

                break;

            case 2:

                GameObjOn();

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

}
