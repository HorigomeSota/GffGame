using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChenge : MonoBehaviour
{
    [SerializeField] private Material materialBlue;
    [SerializeField] private Material materialRed;

    private void Update()
    {
        if (GetComponent<PlayerState>().GetColorChangeFlag())//cloroChangeのフラグがたっているか確認
        {
            GetComponent<PlayerState>().ColorChange();

            //色情報取得
            if (GetComponent<PlayerState>().GetColor() == 0)
            {
                //色（見た目）変える
                gameObject.GetComponent<Renderer>().material = materialBlue;
            }
            else
            {
                //色（見た目）変える
                gameObject.GetComponent<Renderer>().material = materialRed;
            }
            
            
        }
    }
}
