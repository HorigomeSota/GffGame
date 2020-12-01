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

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - player.transform.position.x <= STAGE_CREATE_DIS)
        {
            GetComponent<StageCreate>().Generate();
        }
    }
}
