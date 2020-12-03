using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDistance : MonoBehaviour
{
    private GameObject player;

    const int STAGE_CREATE_DIS = 20;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //距離が縮まったらステージ生成
        if (this.transform.position.x - player.transform.position.x <= STAGE_CREATE_DIS)
        {
            GetComponent<StageCreate>().Generate();
        }

    }
}
