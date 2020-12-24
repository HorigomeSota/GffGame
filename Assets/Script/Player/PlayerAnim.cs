using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
    }


    public void JunpAnimOn()
    {
        m_anim.SetBool("JumpAnim", true);
    }

    public void JunpAnimOff()
    {
        m_anim.SetBool("JumpAnim", false);
    }

    public void DashAnimOn()
    {
        m_anim.SetBool("DashAnim", true);
    }

    public void DashAnimOff()
    {
        m_anim.SetBool("DashAnim", false);
    }

    public void SpeedUpAnimOn()
    {
        m_anim.SetBool("SpeedUpAnim", true);
    }

    public void SpeedUpAnimOff()
    {
        m_anim.SetBool("SpeedUpAnim",false);
    }



}