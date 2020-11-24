using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /// <summary>
    /// ジャンプの向き
    /// </summary>
    private Vector3 m_jumpForce;
    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// ジャンプの力
    /// </summary>
    [SerializeField] private float m_jumpPower;


    private void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();

        if(m_jumpForce== new Vector3(0,0,0))
        m_jumpForce = new Vector3(0, 1, 0);

        if(m_jumpPower==0)
        m_jumpPower = 10;

    }

    private void Update()
    {
        if (Input.anyKeyDown) Jump();
    }

    private void Jump()
    {
        m_PlayerRigidbody.AddForce(m_jumpForce * m_jumpPower, ForceMode.Impulse);
    }




}
