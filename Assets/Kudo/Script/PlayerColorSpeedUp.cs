using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSpeedUp : MonoBehaviour
{
    PlayerState m_playerState;

    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// スピード
    /// </summary>
    [SerializeField] private float m_speed;

    [SerializeField] private float m_justTolerance;
    [SerializeField] private float m_goodTolerance;
    [SerializeField] private float m_okTolerance;

    private float m_judgment;


    private void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();

        m_playerState = GetComponent<PlayerState>();

        m_justTolerance = 0.1f;
        m_goodTolerance = 0.25f;
        m_okTolerance = 0.5f;
       

        if (m_speed == 0)
            m_speed = 10;

    }


    
    


    private void Update()
    {
        if (m_playerState.GetColorChangeNowFlag()&&ToleranceCheck()) ColorSpeedUp();
    }

    private bool ToleranceCheck()
    {
       
        //許容範囲の計算
        m_judgment = Mathf.Abs(m_playerState.GetTriggerObj().transform.position.x - transform.position.x);

        //範囲内ならtrueを返す
        if (m_playerState.GetTriggerObj().transform.localScale.x / 2 >= m_judgment) return true;
        
        else return false;
    }


    private void ColorSpeedUp()
    {
        if (m_judgment <= m_justTolerance * m_playerState.GetTriggerObj().transform.position.x) m_speed = 12;

        else if (m_judgment < m_goodTolerance * m_playerState.GetTriggerObj().transform.position.x) m_speed = 11;

        else if (m_judgment < m_okTolerance * m_playerState.GetTriggerObj().transform.position.x) m_speed = 10;


        m_PlayerRigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);
    }

}
