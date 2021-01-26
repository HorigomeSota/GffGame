using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDistance : MonoBehaviour
{
    StageCreate stageCreate = default;
    private GameObject player = default;

    private bool m_start = default;

    const int STAGE_CREATE_DIS = 20;
    void Start()
    {
        player = GameObject.Find("Player");

        stageCreate = GetComponent<StageCreate>();

        Invoke("StageCreate()",2f);
    }

    void Update()
    {
        //距離が縮まったらステージ生成
        if (this.transform.position.x - player.transform.position.x <= STAGE_CREATE_DIS)
        {
            stageCreate.Generate();
        }
    }

    public void StartCreate()
    {
        if (m_start == false)
        {
            player.transform.position = new Vector3(0, 50, -0.4f);
            m_start = true;
        }
    }
}
