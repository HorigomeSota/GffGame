using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody playerRigidbody;

   
    /// <summary>
    /// 重力
    /// </summary>
    [SerializeField] private float gravity=9.8f;

    /// <summary>
    /// プレイヤーの下限値
    /// </summary>
    [SerializeField] private float m_playerTransformLimit;

    /// <summary>
    /// fallのオンオフ切り替え用
    /// </summary>
    [SerializeField] private bool m_fallSwich=false;

    [SerializeField] private float m_time;



    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_time = 0;
            m_fallSwich = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) m_fallSwich = false;

       
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(Vector3.down * gravity);
    }


    private void LateUpdate()
    {
        if (transform.position.y < m_playerTransformLimit)
        {
            transform.position =new Vector3(transform.position.x, m_playerTransformLimit,transform.position.z);
        }
    }
}
