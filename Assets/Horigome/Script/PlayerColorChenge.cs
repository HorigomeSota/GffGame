using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChenge : MonoBehaviour
{
    private void Update()
    {
        if(GetComponent<PlayerState>().GetColorChangeFlag())//cloroChangeのフラグがたっているか確認
        {
            GetComponent<PlayerState>().ColorChange();
        }
    }
}
