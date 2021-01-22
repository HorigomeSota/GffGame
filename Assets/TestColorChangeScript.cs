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
        if (Input.GetKeyDown(KeyCode.A))
        {
            _colorChange.SetColors(StageColorChange.Colors.PinkPurple, StageColorChange.Colors.Yellow);
            _colorChange.SetColorPlayer();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _colorChange.SetColors(StageColorChange.Colors.Blue, StageColorChange.Colors.Red);
            _colorChange.SetColorPlayer();
        }
    }
}
