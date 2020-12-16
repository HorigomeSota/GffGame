using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Gimmick
{
    private float g_floorPositionY;
    // Start is called before the first frame update
    void Start()
    {
        g_floorPositionY = transform.position.y;
    }

    public float  GetPositionY()
    {
        //g_floorPositionYをプレイヤーに渡す
        return g_floorPositionY;
    }


}
