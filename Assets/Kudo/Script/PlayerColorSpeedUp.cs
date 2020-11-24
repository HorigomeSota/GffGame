using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSpeedUp : MonoBehaviour
{
    
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

        m_justTolerance = 0.1f;
        m_goodTolerance = 0.25f;
        m_okTolerance = 0.5f;
       

        if (m_speed == 0)
            m_speed = 10;

    }

    //colorChangeNowがtrue&&許容範囲内

    //m_judgment=Mathf.Abs(許容範囲オブジェクト.x-transform.position.x)
    //m_judgment<m_justTolerance*許容範囲オブジェクト.scale.x
    //speed=12;

    //m_judgment<m_goodTolerance*許容範囲オブジェクト.scale.x
    //speed=11;

    //m_judgment<m_okTolerance*許容範囲オブジェクト.scale.x
    //speed=10;


    private void Update()
    {
        if (Input.anyKeyDown) ColorSpeedUp();
    }

    private void ColorSpeedUp()
    {
        

        m_PlayerRigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);
    }

}
