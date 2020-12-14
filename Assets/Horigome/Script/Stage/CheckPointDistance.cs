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
        if (this.transform.position.x - player.transform.position.x <= STAGE_CREATE_DIS)
        {
            GetComponent<StageCreate>().Generate();
        }

    }

    public void StartCreate()
    {
        if (m_start == false)
        {
            player.transform.position = new Vector3(0, 5, -0.4f);
            m_start = true;
        }
        
    }

}
