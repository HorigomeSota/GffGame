using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDeath : MonoBehaviour
{

    PlayerState m_playerState;

    // Start is called before the first frame update
    void Start()
    {
        m_playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -3)
        {
            m_playerState.DeathFlagOn();
        }
    }
}
