using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOrder : MonoBehaviour
{
    //ステージの順番とファイル名
    string[] g_stageOrder;
    //次のステージ番号
    private int g_nextStageNo;

    //レベルに応じた確率の2次元配列
    int[,] g_endlessProbability;

    //エンドレスモードかどうか
    bool g_endless;

    //エンドレスモードで何回生成したか
    int g_endlessCount;

    /// <summary>
    /// 最初のステージ番号（0オリジン）※endlessを指定したらエンドレスモードから
    /// </summary>
    /// <param name="firstStage"></param>
    public void SetFirstStage(int firstStage)
    {

        //エンドレスモードの確認
        if (g_stageOrder[firstStage] == "Endless") { g_endless = true; }
        g_nextStageNo = firstStage;
    }

    /// <summary>
    /// 次のステージのCSVファイル名取得
    /// </summary>
    /// <returns>CSVファイル名</returns>
    public string GetNextStage()
    {
        
        //エンドレスモードじゃないとき次のステージのファイル名取得
        if (!g_endless)
        {
            string m_nextStage;
            m_nextStage = g_stageOrder[g_nextStageNo];
            g_nextStageNo += 1;
            if (g_stageOrder[g_nextStageNo] == "Endless") { g_endless = true; }
            return m_nextStage;
        }
        //エンドレスモード時、確率によって生成ステージ決定
        else
        {
            int m_level=1;
            //現在のレベル確認（縦列）
            while (true)
            {
                if (g_endlessProbability[m_level, 0] == -1)
                {
                    break;
                }
                else if (g_endlessProbability[m_level, 0] >= g_endlessCount && g_endlessCount > g_endlessProbability[m_level - 1, 0])
                {
                    break;
                }
                else { m_level++; }
            }

            //レベルに応じて、確率でステージ決定（横列）
            int m_stageSelect = Random.Range(1, 101);
            int m_stageNo = 1;
            int m_sum = 0;
            while (true)
            {
                m_sum += g_endlessProbability[m_level, m_stageNo];
                if (m_stageSelect <= m_sum)
                {
                    break;
                }
                if (m_stageSelect + 1 == GetComponent<EndlessProbabilityCSVread>().GetWidth())
                {
                    break;
                }
                else { m_stageNo++; }
            }

            g_endlessCount++;

            return "Endless/"+ g_stageOrder[g_nextStageNo + m_stageNo];
        }
    }

   /* void Awake()
    {
       // g_endless = false;
        g_stageOrder= GetComponent<StageOrderCSVread>().PrepareStageOrder();
       // GetComponent<EndlessProbabilityCSVread>().StartCoroutine("ReadCsv()");
       g_endlessProbability = GetComponent<EndlessProbabilityCSVread>().GetProbabilityDatas();
    }
   */

    public void SetStageOrder(string[] stargeOrder)
    {
        g_stageOrder = stargeOrder;
    }

    /// <summary>
    /// ステージ一覧取得用メソッド
    /// </summary>
    /// <returns></returns>
    public string[] GetStageOrder()
    {
        return g_stageOrder;
    }

    /// <summary>
    /// 現在のステージの番号取得用メソッド
    /// </summary>
    /// <returns></returns>
    public int GetStageNumber()
    {
        return g_nextStageNo-1;
    }

    public void SetEndlessProbability(int[,] EndlessProbability)
    {
        g_endlessProbability = EndlessProbability;
    }

    private void Start()
    {
        g_endlessCount = 1;
    }
}
