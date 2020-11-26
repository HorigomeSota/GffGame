using System.Collections;
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

    private bool fallSwich = false;



    private void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();
        m_playerState = GetComponent<PlayerState>();
    }

    private void FixedUpdate()
    {
        
        if (m_playerState.GetPlayerStatus() == 1)
        {
            //下方向に力を加える
            m_playerRigidbody.AddForce(Vector3.down * gravity);

            
        }
       
    }

    private void LateUpdate()
    {

        if (m_playerState.GetTriggerObj() != null)
        {

            //床のy座標取得
            m_playerTransformLimit = m_playerState.GetTriggerObj().transform.position.y;

            if (transform.position.y < m_playerTransformLimit)
            {
                transform.position = new Vector3(transform.position.x, m_playerTransformLimit, transform.position.z);

               
            }
            


            //moveに戻す
            m_playerState.Move();
        }

       

       

    }
}
