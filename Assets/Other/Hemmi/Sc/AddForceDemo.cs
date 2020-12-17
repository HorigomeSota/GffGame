using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(30, 0, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
