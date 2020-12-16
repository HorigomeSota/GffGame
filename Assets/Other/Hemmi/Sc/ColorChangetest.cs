using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangetest : MonoBehaviour
{
    Material materialRed;
    Material materialBlue;

    // Start is called before the first frame update
    void Start()
    {
        materialRed = Resources.Load<Material>("Materials/Red");
        materialBlue = Resources.Load<Material>("Materials/Blue");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            materialRed.color = Color.white;
            gameObject.GetComponent<Renderer>().material = materialRed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            materialRed.color = Color.red;  
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            materialBlue.SetColor(name, Color.black);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            materialBlue.SetColor(name, Color.blue);
        }
    }
}
