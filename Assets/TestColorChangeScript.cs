using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorChangeScript : MonoBehaviour
{
    [SerializeField]GameObject _colorPatternObj;
    StageColorPattern _colorPattern;

    private void Start()
    {
        _colorPatternObj = GameObject.FindGameObjectWithTag("StageColor");
        _colorPattern = _colorPatternObj.GetComponent<StageColorPattern>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _colorPattern.SetColors(StageColorPattern.Colors.PinkPurple, StageColorPattern.Colors.Yellow);
            _colorPattern.SetColorPlayer();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _colorPattern.SetColors(StageColorPattern.Colors.Blue, StageColorPattern.Colors.Red);
            _colorPattern.SetColorPlayer();
        }
    }
}
