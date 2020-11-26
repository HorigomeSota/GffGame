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
    [SerializeField] private float m_speed;


    private void Start()
    {
        m_playerState = GetComponent<PlayerState>();

        m_PlayerRigidbody = GetComponent<Rigidbody>();

        
        if (m_speed == 0)
            m_speed = 10;

    }

    private void Update()
    {
        if (m_playerState.GetPanelSpeedUpFlag()==true) PanelSpeedUp();
    }

    private void PanelSpeedUp()
    {

        //ここで向きを取得する
        m_panelForce = m_playerState.GetTriggerObj().GetComponent<Panel>().GetVector();

        //力を加える
        m_PlayerRigidbody.AddForce(m_panelForce * m_speed, ForceMode.Impulse);

        //PanelSpeedUpFlagをoff
        m_playerState.PanelSpeedUpFlagOff();
    }


}
