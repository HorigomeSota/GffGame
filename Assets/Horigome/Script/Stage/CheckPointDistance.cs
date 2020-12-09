using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDistance : MonoBehaviour
{
    private GameObject player;

    private bool m_start = false;

    const int STAGE_CREATE_DIS = 20;
    void Start()
    {
        player = GameObject.Find("Player");

        Invoke("StageCreate()",2f);
    }

    void Update()
    {
        //距離が縮まったらステージ生成
        if (this.transform.position.x - player.transform.position.x <= STAGE_CREATE_DIS&&m_start)
        {
            GetComponent<StageCreate>().Generate();
        }

    }

    public void StartCreate()
    {
        m_start = true;
    }

}
