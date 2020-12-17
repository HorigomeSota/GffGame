using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] private int m_stageNumber=default;
    private Transform m_stageSelecteTransform;
    StageSelect m_stageSelecteClass;


    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// ステージ番号を返す   
    /// </summary>
    /// <returns></returns>
    public void GetStageNumber()
    {
        print(m_stageNumber);
        //return m_stageNumber;
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
