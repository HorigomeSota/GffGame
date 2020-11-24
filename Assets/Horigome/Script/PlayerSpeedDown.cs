using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedDown : MonoBehaviour
{
    Rigidbody playerRigid;

    [SerializeField, Header("減速度")]
    private float m_deceleration = 0.1f;

    private void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    const int cSpeeddown = 3;
    private void FixedUpdate()
    {
        if (GetComponent<PlayerState>().GetPlayerStatus() == cSpeeddown)//cSpeeddownの時
        {
            if (playerRigid.velocity.x <= 0)
            {
                //動きとめる
                playerRigid.velocity = new Vector3(0f, playerRigid.velocity.y, playerRigid.velocity.z);
                //死ぬ処理送る
                GetComponent<PlayerState>().DeathFlagOn();
            }
            else
            {
                //最高速より遅い時、徐々に遅くする
                playerRigid.velocity = new Vector3(playerRigid.velocity.x - m_deceleration, playerRigid.velocity.y, playerRigid.velocity.z);
            }
        }
    }
}
