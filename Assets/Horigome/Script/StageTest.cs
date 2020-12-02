using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTest : MonoBehaviour
{
    [SerializeField]
    int firststage;

    void Start()
    {
        GetComponent<StageOrder>().SetFirstStage(firststage);
    }
}
