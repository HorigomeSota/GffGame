﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのステータス
    /// </summary>
    PlayerState m_playerState;

    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_playerRigidbody;
   
    /// <summary>
    /// 重力
    /// </summary>
    [SerializeField] private float gravity=9.8f;

    /// <summary>
    /// プレイヤーの下限値
    /// </summary>
    [SerializeField] private float m_playerTransformLimit;


    private float addGravity=0;

    const float speedMax=-30f;

    private void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();
        m_playerState = GetComponent<PlayerState>();
    }

    private void FixedUpdate()
    {

        if (m_playerState.GetPlayerStatus() == 1 && m_playerRigidbody.velocity.y > speedMax)
        {

            addGravity += 2f;
            //下方向に力を加える
            m_playerRigidbody.AddForce(Vector3.down * (gravity + addGravity));
        }

    }

    private void LateUpdate()
    {

        if (m_playerState.GetTriggerObj() != null && (m_playerState.GetFlore() || m_playerState.GetTriggerObj().tag == "ToleranceValue"))
        {

            //床のy座標取得
            m_playerTransformLimit = m_playerState.GetTriggerObj().transform.position.y;

            if (transform.position.y < m_playerTransformLimit)
            {
                transform.position = new Vector3(transform.position.x, m_playerTransformLimit, transform.position.z);

                m_playerRigidbody.velocity = new Vector3(m_playerRigidbody.velocity.x, 0, m_playerRigidbody.velocity.z);


                m_playerState.Move();
                addGravity = 0;
            }





        }
        else if (/*(m_playerState.GetTriggerObj().tag == null|| m_playerState.GetTriggerObj().tag == "Enemy")  &&*/ !m_playerState.GetFlore())
        {
            m_playerState.Fall();
        }
        

       

       

    }
   

}
