using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecte : MonoBehaviour
{

    

    [SerializeField]
    private GameObject[] m_stages=new GameObject[9];//ステージ起動プレハブ入れよう

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StageTransition(int stageNumber)
    {
        //ここで選んだステージの番号渡す


    }
}
