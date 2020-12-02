using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelSpeedUp : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのステータス
    /// </summary>
    PlayerState m_playerState;

    /// <summary>
    /// Panelの向き
    /// </summary>
    private Vector3 m_panelForce;
    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// スピード
    /// </summary>
    private float m_speed;

    private float m_timeSpeedUp;

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

        if (m_speed == 0)
            m_speed = 25;



    }

    private void Update()
    {
        if (m_playerState.GetPanelSpeedUpFlag() == true) {
            //PanelSpeedUpFlagをoff
            m_playerState.PanelSpeedUpFlagOff();
            PanelSpeedUp();

        }

    }

    private void PanelSpeedUp()
    {
        Debug.Log("PanelSpeedUp");
        if(m_playerState.GetTriggerObj()!=null&& m_playerState.GetTriggerObj().tag == "Panel")
        {
            //ここで向きを取得する
            m_panelForce = m_playerState.GetTriggerObj().GetComponent<Panel>().GetVector();

            Debug.Log("x"+m_panelForce.x+ "y"+ m_panelForce.y+ "z" + m_panelForce.z);
        }

        m_timeSpeedUp = 0.3f;

        m_audioManager.PlayClip("PanelSpeedUp");

        
    }

    private void FixedUpdate()
    {

        if (m_timeSpeedUp >= 0)
        {
            //力を加える
            m_PlayerRigidbody.velocity = m_panelForce * m_speed;
            m_timeSpeedUp = m_timeSpeedUp - Time.deltaTime;
        }


    }


}
