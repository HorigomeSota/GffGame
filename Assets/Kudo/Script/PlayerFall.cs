using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
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





    private void Start()
    {
        m_playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //stateがfallの時
        //下方向に力を加える
        m_playerRigidbody.AddForce(Vector3.down * gravity);
    }


    private void LateUpdate()
    {
        if (m_playerRigidbody.velocity.y<0)
        {
            //m_playerTransformLimit=床のオブジェクト.y

            if (transform.position.y < m_playerTransformLimit) transform.position = new Vector3(transform.position.x, m_playerTransformLimit, transform.position.z);

        }

    }
}
