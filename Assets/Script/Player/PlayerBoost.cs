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
    private GameObject m_audioManagerObject;

    [SerializeField]
    private AudioManager m_audioManager;

    [SerializeField]
    private GameObject m_boostEfect;
    private void Start()
    {

        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");


        //インスタンス化
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        m_playerState = GetComponent<PlayerState>();
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_boostEfect = transform.GetChild(0).gameObject;


        if (m_speed == 0)
            m_speed = 11;

    }

    private void Update()
    {
        

        if (m_playerState.GetBoostFlag())
        {
           

            if(!boostSwich) m_audioManager.PlayClip("Boost", 0); 

            boostSwich = true;
            m_playerState.Boost();
            StartCoroutine(Boost());
            
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
        m_boostEfect.SetActive(true);

        //時間待ち
        yield return new WaitForSeconds(boostTime);

        boostSwich = false;

        m_playerState.BoostFlagOff();
        m_boostEfect.SetActive(false);

        yield break;
    }

    private void AudoPlay()
    {

    }
}
