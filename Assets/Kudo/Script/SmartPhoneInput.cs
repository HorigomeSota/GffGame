using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneInput :MonoBehaviour,Input
{
    /// <summary>
    /// trueの時、ジャンプする
    /// </summary>
    private bool m_jumpCheck = false;
    /// <summary>
    /// trueの時、色を変える
    /// </summary>
    private bool m_colorCheck = true;


    bool Input.JumpCheck()
    {
        return m_jumpCheck;
    }

    bool Input.ColorCheck()
    {
        return m_colorCheck;
    }

    void Input.Reset()
    {
        m_colorCheck = false;
        m_jumpCheck = false;
    }

    //右側がタップされたとき　m_jumpCheck　をtrue
    public void RightScreenTap()
    {
        m_jumpCheck = true;
    }

    //左側がタップされたとき　m_colorCheck　をtrue
    public void LeftScreenTap()
    {
        m_colorCheck = true;
     }


    

}
