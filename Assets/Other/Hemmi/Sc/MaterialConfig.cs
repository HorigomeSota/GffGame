using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialConfig : MonoBehaviour
{
    /// <summary>
    /// 追加するときはenumとスタートの処理順合わせてね！
    /// </summary>
    [SerializeField]enum MaterialState
    {
        Red,
        Blue,
        Yellow,
        Orange,
        PinkPurple,
        LightGreen,
        LemonYellow,
        White,
    }

    [SerializeField]Material[] m_materials=new Material[10];

    [SerializeField]private MaterialState m_materialState;

    // Start is called before the first frame update
    void Start()
    {
        m_materials[0] = Resources.Load<Material>("Materials/Red");
        m_materials[1] = Resources.Load<Material>("Materials/Blue");
        m_materials[2] = Resources.Load<Material>("Materials/Yellow");
        m_materials[3] = Resources.Load<Material>("Materials/Orange");
        m_materials[4] = Resources.Load<Material>("Materials/PinkPurple");
        m_materials[5] = Resources.Load<Material>("Materials/LightGreen");
        m_materials[6] = Resources.Load<Material>("Materials/LemonYellow");
        m_materials[7] = Resources.Load<Material>("Materials/White");

        MaterialSet();

    }

    /// <summary>
    /// 外から呼ぶ予定ないけどとりあえずパブリックに。今持ってるステイトに合わせた色になります。
    /// </summary>
    public void MaterialSet()
    {
        switch (m_materialState)
        {
            case MaterialState.Red:
                GetComponent<Renderer>().material = m_materials[0];
                break;

            case MaterialState.Blue:
                GetComponent<Renderer>().material = m_materials[1];
                break;

            case MaterialState.Yellow:
                GetComponent<Renderer>().material = m_materials[2];
                break;

            case MaterialState.Orange:
                GetComponent<Renderer>().material = m_materials[3];
                break;

            case MaterialState.PinkPurple:
                GetComponent<Renderer>().material = m_materials[4];
                break;

            case MaterialState.LightGreen:
                GetComponent<Renderer>().material = m_materials[5];
                break;

            case MaterialState.LemonYellow:
                GetComponent<Renderer>().material = m_materials[6];
                break;

            case MaterialState.White:
                GetComponent<Renderer>().material = m_materials[7];
                break;
        }

    }
}
