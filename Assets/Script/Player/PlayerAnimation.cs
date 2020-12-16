using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private AnimationClip DashClip;
    private AnimationClip JumpClip;
    private AnimationClip UpClip;


    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }




}
