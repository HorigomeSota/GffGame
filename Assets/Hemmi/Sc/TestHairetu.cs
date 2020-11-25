using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHairetu : MonoBehaviour
{
    private GameObject[] testObj = new GameObject[4];
    private GameObject testMost;
    [SerializeField] private GameObject aaa;

    // Start is called before the first frame update
    void Start()
    {
        testObj[2] = aaa;
        Debug.Log(Array.IndexOf(testObj,null));
        //testMost = testObj[Array.IndexOf(testObj, gameObject)];
        Debug.Log(testMost);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
