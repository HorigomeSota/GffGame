﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Gimmick
{
    Vector3 g_forceVecter;


    private Vector3[] m_forceVecter3s =
    {

        new Vector3(1,0,0),    //0度
        new Vector3((Mathf.Sqrt(6)+Mathf.Sqrt(2))/4,(Mathf.Sqrt(6)-Mathf.Sqrt(2))/4,0),    //15度
        new Vector3 (Mathf.Sqrt(3)/2,0.5f, 0),     //30度
        new Vector3(1/Mathf.Sqrt(2), 1/Mathf.Sqrt(2), 0),      //45度
        new Vector3(0.5f,Mathf.Sqrt(3)/2,0),        //60度
        new Vector3((Mathf.Sqrt(6)-Mathf.Sqrt(2))/4,(Mathf.Sqrt(6)+Mathf.Sqrt(2))/4,0),        //75度
        new Vector3(0,1,0)      //90度

    };

    [SerializeField] private int m_panelRotation = 0;//ここに角度を入れると、オブジェクトの角度も、向きも、全部求めて変更するよ！
    

    public void SetRotation(int rotation)
    {
        m_panelRotation = rotation;
    }
 
    public void SetAngle()
    {
        g_forceVecter = default;

        switch (m_panelRotation)//角度に応じて、パネルのforceの向きを決める
        {
            case 0:
                g_forceVecter = m_forceVecter3s[0];
                break;

            case 15:
                g_forceVecter = m_forceVecter3s[1];
                break;

            case 30:
                g_forceVecter = m_forceVecter3s[2];
                break;

            case 45:
                g_forceVecter = m_forceVecter3s[3];
                break;

            case 60:
                g_forceVecter = m_forceVecter3s[4];
                break;

            case 75:
                g_forceVecter = m_forceVecter3s[5];
                break;

            case 90:
                g_forceVecter = m_forceVecter3s[6];
                break;
        }

    }


   

    /// <summary>
    /// パネルの向き取得用
    /// </summary>
    /// <returns></returns>
    public Vector3 GetVector()
    {

        SetAngle();
        return g_forceVecter;
        
    }

}
