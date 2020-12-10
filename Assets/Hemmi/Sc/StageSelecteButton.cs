using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecteButton : MonoBehaviour
{
    [SerializeField] private int m_stageNumber=default;
    private Transform m_stageSelecteTransform;
    StageSelecte m_stageSelecteClass;


    // Start is called before the first frame update
    void Start()
    {
        m_stageSelecteTransform = GameObject.Find("StageSelecte").transform;

        m_stageSelecteClass = m_stageSelecteTransform.GetComponent<StageSelecte>();
    }

    
    public void StageChange()
    {
        m_stageSelecteClass.StageTransition(m_stageNumber);
        

    }
}
