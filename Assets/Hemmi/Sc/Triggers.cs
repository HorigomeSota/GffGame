using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    [SerializeField] private GameObject[] m_triggerStays=new GameObject[5];//触れているオブジェクトを配列で優先度順に管理  (0=Enemy,1=Shortcut,2=Panel,3=ToleranceValue,4=Floor)

    [SerializeField] private GameObject g_mostPriority;//触れているオブジェクトの中で、優先度が一番高いものを保持しておく

    [SerializeField] private int[] m_prioritys=new int[5];//現在保有している優先度すべて
    private int m_priorityMax;//一番高い優先度を保持
    private int m_priorityEnter;//今触れたオブジェクトの優先度の値を保持
    private int m_priorityExit;//今出ていったオブジェクトの優先度

    [SerializeField] private GameObject m_player;//プレイヤー取得


    private void Start()
    {
        m_player = GameObject.Find("Player");
        

        m_priorityMax = 5;
        int loopCount = 4;
        while (loopCount >= 0)//初期化
        {
            m_prioritys[loopCount] = -1;
            loopCount--;
        }
        
    }

    private void FixedUpdate()
    {
        //プレイヤーのゲームオブジェクト受け取るやつ呼び出すm_player.GetComponent<プレイヤーステイト>().呼び出すやつ(g_mostPriority);

    }

    private void OnTriggerEnter(Collider other)//触れたオブジェクトを配列に追加
    {

        switch (other.gameObject.tag)
        {
            case "Enemy":
                m_priorityEnter = 0;
                break;

            case "Shortcut":
                m_priorityEnter = 1;
                break;

            case "Panel":
                m_priorityEnter = 2;
                break;

            case "ToleranceValue":
                m_priorityEnter = 3;
                break;

            case "Floor":
                m_priorityEnter = 4;
                break;
        }
        m_triggerStays[m_priorityEnter] = other.gameObject;
        m_prioritys[m_priorityEnter] = m_priorityEnter;

        if (m_priorityMax > m_priorityEnter)//今触れたやつの優先度が保持している奴の優先度より高いなら、優先度一番高い奴として格納
        {
            m_priorityMax = m_priorityEnter;
            g_mostPriority = m_triggerStays[Array.IndexOf(m_triggerStays, other.gameObject)];

        }
        

    }

    private void OnTriggerExit(Collider other)//離れたオブジェクトを配列から排除
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                m_priorityExit = 0;
                break;

            case "Shortcut":
                m_priorityExit = 1;
                break;

            case "Panel":
                m_priorityExit = 2;
                break;

            case "ToleranceValue":
                m_priorityExit = 3;
                break;

            case "Floor":
                m_priorityExit = 4;
                break;
        }
        m_triggerStays[m_priorityExit] = null;
        m_prioritys[m_priorityExit] = -1;

        if (m_priorityMax== m_priorityExit)//もし、離れたオブジェクトの優先度が、最高優先度だったら、次に優先度の高いオブジェクトを最高優先度に設定する
        {
            int m_rePriorityMax = 4;
            while (m_rePriorityMax>=0)
            {

                if(Array.IndexOf(m_prioritys, m_rePriorityMax) != -1)
                {
                    m_priorityMax = m_prioritys[Array.IndexOf(m_prioritys, m_rePriorityMax)];
                }
                g_mostPriority = m_triggerStays[m_priorityMax];
                m_rePriorityMax--;
            }
            
        }
        

    }

    

}
