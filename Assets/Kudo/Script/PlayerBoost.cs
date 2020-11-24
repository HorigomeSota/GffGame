using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
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
    private bool boostSwich = false;

    private void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();


        if (m_speed == 0)
            m_speed = 11;

    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            
            boostSwich = true;
            Boost();
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


    IEnumerable Boost()
    {

        //時間待ち
        yield return new WaitForSeconds(boostTime);

        boostSwich = false;


        yield break;
    }

}
