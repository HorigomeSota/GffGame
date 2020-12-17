﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject m_titleRootObj=default;
    [SerializeField] private GameObject m_GameRootObj=default;
    [SerializeField] private GameObject m_StageRootObj=default;
    [SerializeField] private GameObject m_CanvasObject=default;

    private GameObject m_gameManager;

    IInput m_input;

    private void Start()
    {
      
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

            case 3:

                Retry();

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}