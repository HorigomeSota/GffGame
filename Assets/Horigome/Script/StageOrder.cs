using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOrder : MonoBehaviour
{
    string[] g_stageOrder;
    private int g_nextStageNo;

    bool g_endless;

    public void SetFirstStage(int firstStage)
    {
        if (g_stageOrder[firstStage] == "Endless") { g_endless = true; }
        else { g_nextStageNo = firstStage; }
    }

    public string GetNextStage()
    {
        if (!g_endless)
        {
            string m_nextStage;
            m_nextStage = g_stageOrder[g_nextStageNo];
            g_nextStageNo += 1;
            if (g_stageOrder[g_nextStageNo] == "Endless") { g_endless = true; }
            return m_nextStage;
        }
        else
        {
            return g_stageOrder[g_nextStageNo];
        }
    }

    void Awake()
    {
        g_endless = false;
        g_stageOrder= GetComponent<StageOrderCSVread>().PrepareStageOrder();
    }

    void Update()
    {
        
    }
}
