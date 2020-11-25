using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    protected int color;
    protected GameObject player;

    public virtual int GetColor()//カラーを渡す
    {
        
        return color;
    }


}
