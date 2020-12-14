using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    GameObject m_stageSelecte=default;


    public void TapScreen()
    {
        m_stageSelecte.SetActive(true);
        gameObject.SetActive(false);
    }

}
