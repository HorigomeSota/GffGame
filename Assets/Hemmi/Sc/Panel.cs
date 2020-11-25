using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : Gimmick
{
    private Vector3 g_forceVecter = new Vector3(0, 0, 0);

    private Vector3[] m_forceVecter3s =
    {
        new Vector3(1,0,0),    //0度
        new Vector3(Mathf.Sqrt(6)-Mathf.Sqrt(2)/4,Mathf.Sqrt(6)+Mathf.Sqrt(2)/4,0),    //15度
        new Vector3 (Mathf.Sqrt(3)/2, 1/2, 0),     //30度
        new Vector3(1/Mathf.Sqrt(2), 1/Mathf.Sqrt(2), 0),      //45度
        new Vector3(1/2,Mathf.Sqrt(3)/2,0),        //60度
        new Vector3(Mathf.Sqrt(6)+Mathf.Sqrt(2)/4,Mathf.Sqrt(6)-Mathf.Sqrt(2)/4,0),        //75度
        new Vector3(0,1,0)      //90度
    };
    [SerializeField] private float m_power = 10;

    [SerializeField] private int m_panelRotation = 0;//ここに角度を入れると、オブジェクトの角度も、向きも、全部求めて変更するよ！
    // Start is called before the first frame update
    private void Awake()
    {
        transform.Rotate(new Vector3(0, 0, m_panelRotation));//オブジェクトの角度変更
        switch (m_panelRotation)//角度に応じて、パネルのforceの向きを決める
        {
            case 0:
                g_forceVecter = m_forceVecter3s[0];
                break;

            case 15:
                g_forceVecter = m_forceVecter3s[1];
                break;

            case 30:
                g_forceVecter = m_forceVecter3s[2];
                break;

            case 45:
                g_forceVecter = m_forceVecter3s[4];
                break;

            case 60:
                g_forceVecter = m_forceVecter3s[5];
                break;

            case 75:
                g_forceVecter = m_forceVecter3s[6];
                break;

            case 90:
                g_forceVecter = m_forceVecter3s[7];
                break;
        }
    }
    


    public Vector3 GetVector()//vector渡す
    {
        return g_forceVecter;
    }

}
