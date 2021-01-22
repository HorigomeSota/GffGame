using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Triggers : MonoBehaviour
{
    [SerializeField] private GameObject[] m_triggerStays = new GameObject[6];//触れているオブジェクトを配列で優先度順に管理  (0=Enemy,1=Shortcut,2=Panel,3=ToleranceValue,4=Floor)
    [SerializeField] private GameObject g_mostPriority;//触れているオブジェクトの中で、優先度が一番高いものを保持しておく
    [SerializeField] private int[] m_prioritys = new int[6];//現在保有している優先度すべて
    private int m_priorityMax;//一番高い優先度を保持
    private int m_priorityEnter;//今触れたオブジェクトの優先度の値を保持
    private int m_priorityExit;//今出ていったオブジェクトの優先度
    [SerializeField] private GameObject m_player;//プレイヤー取得
    bool m_nullFrag = false;

    bool g_triggerFlore=false;

    [SerializeField]
    private GameObject m_audioManagerObject;
    AudioManager m_audioManager;

    PlayerState m_playerState;
    private void Start()
    {
        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //インスタンス化
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_playerState = GetComponent<PlayerState>();
        m_priorityMax = 6;
        int loopCount = 5;
        while (loopCount >= 0)//初期化
        {
            m_prioritys[loopCount] = -1;
            loopCount--;
        }
    }
    private void Update()
    {
        m_playerState.SetTriggerObj(g_mostPriority);//プレイヤーのゲームオブジェクト受け取るやつ呼び出す
    }
    private void OnTriggerEnter(Collider other)//触れたオブジェクトを配列に追加
    {
        switch (other.gameObject.tag)
        {
            case "FallDeath":
                m_priorityEnter = 0;
                break;
            case "Enemy":
                m_priorityEnter = 1;
                break;
            case "Shortcut":
                m_priorityEnter = 2;
                break;
            case "Panel":
                m_priorityEnter = 3;
                break;
            case "ToleranceValue":
                m_priorityEnter = 4;
                break;
            case "Floor":
                m_priorityEnter = 5;
                g_triggerFlore = true;
                break;
            default:
                return;
        }
        m_triggerStays[m_priorityEnter] = other.gameObject;
        m_prioritys[m_priorityEnter] = m_priorityEnter;

        if (m_priorityMax >= m_priorityEnter)//今触れたやつの優先度が保持している奴の優先度より高いなら、優先度一番高い奴として格納
        {
            m_priorityMax = m_priorityEnter;
            g_mostPriority = m_triggerStays[Array.IndexOf(m_triggerStays, other.gameObject)];
        }
    }
    private void OnTriggerExit(Collider other)//離れたオブジェクトを配列から排除
    {
        switch (other.gameObject.tag)
        {
            case "FallDeath":
                m_priorityExit = 0;
                break;

            case "Enemy":
                m_priorityExit = 1;
                break;
            case "Shortcut":
                m_priorityExit = 2;
                break;
            case "Panel":
                m_priorityExit = 3;
                break;
            case "ToleranceValue":
                m_priorityExit = 4;
                break;
            case "Floor":
                m_priorityExit = 5;
                g_triggerFlore = false;
                break;

        }

        if (other.gameObject == m_triggerStays[m_priorityExit])//離れたオブジェクトと触れていたオブジェクトが一致していたら
        {

            m_triggerStays[m_priorityExit] = null;
            m_prioritys[m_priorityExit] = -1;
            //もし、なんのオブジェクトにも触れていなかったら、優先度を最低にするためのフラグON
            //bool m_nullFrag = false;
            int m_nullLoop = 5;
            while (m_nullLoop >= 0)
            {
                if (m_triggerStays[m_nullLoop] == null)
                {
                    m_nullFrag = true;
                }
                else
                {
                    m_nullFrag = false;
                    m_nullLoop = -1;
                }
                m_nullLoop--;
            }
            //優先度再設定
            if (m_nullFrag)//触れているオブジェクトなし
            {
                m_priorityMax = 6;
                g_mostPriority = null;
            }
            else
            if (m_priorityMax == m_priorityExit)//もし、離れたオブジェクトの優先度が、最高優先度だったら、次に優先度の高いオブジェクトを最高優先度に設定する
            {
                int m_rePriorityMax = 5;
                while (m_rePriorityMax >= 0)
                {
                    if (Array.IndexOf(m_prioritys, m_rePriorityMax) != -1)
                    {
                        m_priorityMax = m_prioritys[Array.IndexOf(m_prioritys, m_rePriorityMax)];
                    }
                    g_mostPriority = m_triggerStays[m_priorityMax];
                    m_rePriorityMax--;
                }
            }
        }
    }

    /// <summary>
    /// フロアの情報はべつにして渡す(同時接触による落下防止のため)
    /// </summary>
    /// <returns></returns>
    public GameObject GetFlore()
    {
        return m_triggerStays[5];
    }
}