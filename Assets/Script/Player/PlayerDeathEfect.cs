﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEfect : MonoBehaviour
{
    /// <summary>
    /// 死亡時のエフェクト
    /// </summary>
    [SerializeField]
    private GameObject m_deathEfect=default;

    PlayerState playerState=default;

    SpriteRenderer playerSprite=default;

    /// <summary>
    /// 一度だけ表示するためのbool
    /// </summary>
    private bool efectOnece=true;

    private void Start()
    {
        playerState = GetComponent<PlayerState>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (efectOnece && playerState.GetDeathFlag())
        {
            efectOnece = false;
            DeathEfect();
        }

        if (!playerState.GetDeathFlag())
        {
            efectOnece = true;
        }
    }


    /// <summary>
    /// 死亡時にエフェクトを出す
    /// </summary>
    private void DeathEfect()
    {
        playerSprite.enabled = false;
        Instantiate(m_deathEfect,transform);
    }

}
