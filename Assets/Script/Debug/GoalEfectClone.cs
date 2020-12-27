﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEfectClone : MonoBehaviour
{
    private GameObject goal1;
    private GameObject goal2;
    private GameObject goal3;
    private GameObject goal4;
    private GameObject goal5;
    private GameObject goal6;


    void Start()
    {
        goal1 = transform.GetChild(0).gameObject;
        goal2 = transform.GetChild(1).gameObject;
        goal3 = transform.GetChild(2).gameObject;
        goal4 = transform.GetChild(3).gameObject;
        goal5 = transform.GetChild(4).gameObject;
        goal6 = transform.GetChild(5).gameObject;



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Goal());
            
        }

    }

    IEnumerator Goal()
    {

        goal1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        goal2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        goal3.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        goal4.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        goal5.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        goal6.SetActive(true);
        yield return new WaitForSeconds(0.2f);

        yield break;
    }
}
