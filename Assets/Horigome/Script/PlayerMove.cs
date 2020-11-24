using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Header("最高速")]
    private float m_maxSpeed=25;
    Rigidbody playerRigid;

    [SerializeField,Header("加速度")]
    private float m_acceleration=5;
    [SerializeField,Header("減速度")]
    private float m_deceleration=8;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    const int move = 0;
    private void FixedUpdate()
    {
        if (GetComponent<PlayerState>().GetPlayerStatus() == move)//moveの時
        {
            //最高速より早い時、徐々に早くする
            if (playerRigid.velocity.x < m_maxSpeed) { playerRigid.velocity = new Vector3(playerRigid.velocity.x + m_acceleration, playerRigid.velocity.y, playerRigid.velocity.z); }
            //最高速より遅い時、徐々に遅くする
            else if (playerRigid.velocity.x > m_maxSpeed + m_deceleration) { playerRigid.velocity = new Vector3(playerRigid.velocity.x - m_deceleration, playerRigid.velocity.y, playerRigid.velocity.z); }
            else { playerRigid.velocity = new Vector3(m_maxSpeed, playerRigid.velocity.y, playerRigid.velocity.z); }
        }
    }
}
