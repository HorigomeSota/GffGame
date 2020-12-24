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

    const float m_justTolerance=0.1f;
    const float m_goodTolerance=0.25f;
    const float m_okTolerance=0.5f;

    private float m_judgment;

    /// <summary>
    /// 許容範囲値
    /// </summary>
    const float m_tolerance = 0.5f;


    [SerializeField]
    private GameObject m_audioManagerObject;

    [SerializeField]
    private AudioManager m_audioManager;

    PlayerAnim m_playerAnim;

    private void Start()
    {
        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //インスタンス化
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_PlayerRigidbody = GetComponent<Rigidbody>();
        m_playerState = GetComponent<PlayerState>();
        m_playerAnim = GetComponent<PlayerAnim>();



        if (m_speed == 0)
            m_speed = 10;

    }


    
    


    private void Update()
    {
        if (m_playerState.GetColorChangeNowFlag()&&ToleranceCheck()) ColorSpeedUp();
        m_playerState.ColorChangeNowFlagOff();
    }

    private bool ToleranceCheck()
    {

        if (m_playerState.GetTriggerObj() != null)
        {
            //許容範囲の計算
            m_judgment = Mathf.Abs(m_playerState.GetTriggerObj().transform.position.x - transform.position.x);
            //範囲内　かつ　前の色と今の色が同じとき、trueを返す
            if ( m_playerState.GetTriggerObj().tag == "ToleranceValue" && m_tolerance >= m_judgment && m_playerState.GetColor() != m_playerState.GetTriggerObj().GetComponent<ToleranceValue>().GetColor()) return true;
            else 
            {
                return false;
            }
            

        }

        else return false;


    }


    private void ColorSpeedUp()
    {

        m_playerAnim.SpeedUpAnimOn();

        if (m_judgment < m_justTolerance )
        {
            m_speed = 50;
        }


        else if (m_judgment < m_goodTolerance) 
        {
            m_speed = 40;
        }
        

        else if (m_judgment < m_okTolerance) 
        {

            m_speed = 30;
        }


        m_audioManager.PlayClip("SpeedUp",0);
        
        m_PlayerRigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);

        m_playerAnim.SpeedUpAnimOff();
    }

}
