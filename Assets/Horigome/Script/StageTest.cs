using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTest : MonoBehaviour
{
    [SerializeField]
    int firststage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StageOrder>().SetFirstStage(firststage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
