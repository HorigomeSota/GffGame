using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのステータスClass
    /// </summary>
    PlayerState m_playerState;

    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// スピード
    /// </summary>
    [SerializeField] private float m_speed;

    /// <summary>
    /// boostの時間
    /// </summary>
    private float boostTime = 3;

    /// <summary>
    /// boostのオンオフ
    /// </summary>
   [SerializeField] private bool boostSwich = false;

    [SerializeField]
    private GameObject audioManagerObject;

    [SerializeField]
    private AudioManager m_audioManager;

    private void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();

        m_playerState = GetComponent<PlayerState>();

        m_audioManager = audioManagerObject.GetComponent<AudioManager>();



        if (m_speed == 0)
            m_speed = 11;

    }

    private void Update()
    {
        

        if (m_playerState.GetBoostFlag())
        {
            
            boostSwich = true;
            m_playerState.Boost();
            StartCoroutine("Boost");
            m_audioManager.PlayClip("Boost");
        }

    }

    private void FixedUpdate()
    {
        if (boostSwich)
        {
            //boost時の処理
            m_PlayerRigidbody.velocity = new Vector3(m_speed, 0, 0);

        }


    }


    IEnumerator Boost()
    {
        Debug.Log("sutat");
        //時間待ち
        yield return new WaitForSeconds(boostTime);

        Debug.Log("end");
        boostSwich = false;
        m_playerState.BoostFlagOff();

        yield break;
    }

}
