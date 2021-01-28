using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorChangeScript : MonoBehaviour
{
    [SerializeField]GameObject _colorPatternObj;
    StageColorChange _colorChange;

    private void Start()
    {
        _colorPatternObj = GameObject.FindGameObjectWithTag("StageColor");
        _colorChange = _colorPatternObj.GetComponent<StageColorChange>();
    }

    private void Update()
    {
        
    }
}
