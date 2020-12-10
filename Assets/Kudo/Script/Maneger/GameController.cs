using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject m_titleRootObj;
    private GameObject m_GameRootObj;
    private GameObject m_StageRootObj;

    private void Start()
    {
        m_titleRootObj = GameObject.FindWithTag("TitleRoot");
        m_GameRootObj = GameObject.FindWithTag("GameRoot");
        m_StageRootObj = GameObject.FindWithTag("StageRoot");
    }
    private void Update()
    {

    }

    private void GameObjOn()
    {
        m_titleRootObj.SetActive(false);

        m_StageRootObj.SetActive(false);

        m_GameRootObj.SetActive(true);
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
