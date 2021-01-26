using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] private int m_stageNumber=default;
    private Transform m_stageSelecteTransform;
    StageSelect m_stageSelecteClass;

    void Start()
    {
        Vector3 objectSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.size = objectSize;
    }

    /// <summary>
    /// ステージ番号を返す   
    /// </summary>
    /// <returns></returns>
    public int GetStageNumber()
    {
        return m_stageNumber;
    }

    /// <summary>
    /// ボタンにステージ番号をつける
    /// </summary>
    /// <param name="stageNumber"></param>
    public void SetStageNumber(int stageNumber)
    {
        m_stageNumber = stageNumber-1;
    }
}
