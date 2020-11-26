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

        if (m_playerState.GetTriggerObj() != null)
        {
            //許容範囲の計算
            m_judgment = Mathf.Abs(m_playerState.GetTriggerObj().transform.position.x - transform.position.x);
            //範囲内　かつ　前の色と今の色が同じとき、trueを返す
            if ( m_playerState.GetTriggerObj().tag == "ToleranceValue" && m_playerState.GetTriggerObj().transform.localScale.x / 2 >= m_judgment && m_playerState.GetColor() != m_playerState.GetTriggerObj().GetComponent<ToleranceValue>().GetColor()) return true;
            else 
            {
                m_playerState.ColorChangeNowFlagOff();
                return false;
            }
            

        }

        else return false;


    }


    private void ColorSpeedUp()
    {
        
        m_playerState.ColorChangeNowFlagOff();


        if (m_judgment < m_justTolerance * m_playerState.GetTriggerObj().transform.localScale.x)
        {
            Debug.Log("Just");
            m_speed = 50;
        }


        else if (m_judgment < m_goodTolerance * m_playerState.GetTriggerObj().transform.localScale.x) 
        {
            Debug.Log("Good");
            m_speed = 40;
        }
        

        else if (m_judgment < m_okTolerance * m_playerState.GetTriggerObj().transform.localScale.x) 
        {
            Debug.Log("Ok");
            m_speed = 30;
        }
        


        m_PlayerRigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);
    }

}
