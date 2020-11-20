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

    //仮置きのステート
    [SerializeField]
    int testState=0;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //PlayerStateのStateをチェック

        /* デバッグ
        if (Input.GetKeyDown(KeyCode.Alpha1)) { testState = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { testState = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { testState = 3; }
        Debug.Log(testState);
        Debug.Log(playerRigid.velocity.x);
        */
    }

    private void FixedUpdate()
    {
        if (testState == 2)//moveの時
        {
            //最高速より早い時、徐々に早くする
            if (playerRigid.velocity.x < m_maxSpeed) { playerRigid.velocity = new Vector3(playerRigid.velocity.x + m_acceleration, playerRigid.velocity.y, playerRigid.velocity.z); }
            //最高速より遅い時、徐々に遅くする
            else if (playerRigid.velocity.x > m_maxSpeed + m_deceleration) { playerRigid.velocity = new Vector3(playerRigid.velocity.x - m_deceleration, playerRigid.velocity.y, playerRigid.velocity.z); }
            else { playerRigid.velocity = new Vector3(m_maxSpeed, playerRigid.velocity.y, playerRigid.velocity.z); }
        }

        //デバッグ
        //if (testState == 3) { playerRigid.velocity = new Vector3(m_maxSpeed + 30, playerRigid.velocity.y, playerRigid.velocity.z); }
    }
}
