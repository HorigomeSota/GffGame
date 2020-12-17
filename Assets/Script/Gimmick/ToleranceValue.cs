using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToleranceValue : Gimmick
{
    float g_tolerancePositionY;

    private void Start()
    {
        g_tolerancePositionY = transform.position.y;
    }

    public  float GetPosition()
    {
        //g_floorPositionYをプレイヤーに渡す
        return g_tolerancePositionY;
    }
}
