using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{

    PlayerState m_playerState;
    Rigidbody m_playerRigidbody;

    private void Start()
    {
        m_playerState=GetComponent<PlayerState>();
        m_playerRigidbody=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // stateがnoneの時動かない
        if (m_playerState.GetPlayerStatus() == 4)
        {
            m_playerRigidbody.velocity = Vector3.zero;
        }
    }
}
