using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのステータス
    /// </summary>
    PlayerState m_playerState;

    /// <summary>
    /// ジャンプの向き
    /// </summary>
    private Vector3 m_jumpForce;
    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// ジャンプの力
    /// </summary>
    [SerializeField] private float m_jumpPower;

    [SerializeField]
    private GameObject m_audioManagerObject;

    [SerializeField]
    private AudioManager m_audioManager;

    private void Start()
    {

        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //インスタンス化
        m_playerState = GetComponent<PlayerState>();
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();


        if (m_jumpForce== new Vector3(0,0,0))
        m_jumpForce = new Vector3(0, 1, 0);

        if(m_jumpPower==0)
        m_jumpPower = 10;

    }

    private void Update()
    {
        if (m_playerState.GetJumpFlag() == true) 
        {
            Jump();
        }
        
    }

    private void Jump()
    {
        //上に力を加える
        m_PlayerRigidbody.AddForce(m_jumpForce * m_jumpPower, ForceMode.Impulse);

        //fallに変える
        //m_playerState.Fall();
        //Debug.Log("fallに変ええる");
        m_audioManager.PlayClip("Jump",0);
        Debug.Log("JumpSE");

        //JumpFlagをoff
        m_playerState.JumpFlagOff();
    }




}
