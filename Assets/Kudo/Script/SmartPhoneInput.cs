using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneInput :MonoBehaviour,IInput
{
    /// <summary>
    /// trueの時、ジャンプする
    /// </summary>
    private bool m_jumpCheck = false;
    /// <summary>
    /// trueの時、色を変える
    /// </summary>
   [SerializeField] private bool m_colorCheck = true;


    public bool JumpCheck()
    {
        return m_jumpCheck;
    }

    public bool ColorCheck()
    {
        return m_colorCheck;
    }

    public void Reset()
    {
        m_colorCheck = false;
        m_jumpCheck = false;
    }

    //右側がタップされたとき　m_jumpCheck　をtrue
    public void RightScreenTap()
    {
        Debug.Log("右");
        m_jumpCheck = true;
    }

    //左側がタップされたとき　m_colorCheck　をtrue
    public void LeftScreenTap()
    {
        Debug.Log("左");
        m_colorCheck = true;
     }


    

}
