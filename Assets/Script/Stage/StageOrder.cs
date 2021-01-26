using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOrder : MonoBehaviour
{
    //ステージの順番とファイル名
    string[] g_stageOrder;

    //次のステージ番号
    [SerializeField] private int g_nextStageNo;

    //レベルに応じた確率の2次元配列
    int[,] g_endlessProbability;

    //エンドレスモードかどうか
    bool g_endless;

    /// <summary>
    /// エンドレスモードかどうか
    /// </summary>
    /// <returns>true=エンドレス中,false=エンドレスじゃない</returns>
    public bool GetEndlessNow()
    {
        return g_endless;
    }

    //エンドレスモードで何回生成したか
    int g_endlessCount;

    /// <summary>
    /// ステージの色変更系のスクリプトが入ってるオブジェクト
    /// </summary>
    GameObject _stageColorObject;

    /// <summary>
    /// 色設定スクリプト
    /// </summary>
    StageColorChange _colorChange;

    /// <summary>
    /// ステージの色格納スクリプト
    /// </summary>
    StageColor _stageColor;

    private void Awake()
    {
        _stageColorObject = GameObject.FindGameObjectWithTag("StageColor");
        _colorChange = _stageColorObject.GetComponent<StageColorChange>();
        _stageColor = _stageColorObject.GetComponent<StageColor>();
    }

    /// <summary>
    /// 最初のステージ番号（0オリジン）※endlessを指定したらエンドレスモードから
    /// </summary>
    /// <param name="firstStage"></param>
    public void SetFirstStage(int firstStage)
    {
        Debug.Log("firstStage" + firstStage);

        //エンドレスモードの確認
        if (g_stageOrder[firstStage] == "Endless") { g_endless = true; }
        g_nextStageNo = firstStage;
        //ステージの色設定
        NextStageColor(true);
        _colorChange.SetColorPlayer();
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
        return g_nextStageNo-2;
    }

    public void SetEndlessProbability(int[,] EndlessProbability)
    {
        g_endlessProbability = EndlessProbability;
    }

    private void Start()
    {
        g_endlessCount = 1;
    }

    /// <summary>
    /// 次のステージの色変える
    /// </summary>
    public void NextStageColor()
    {
        _stageColor.StageColorChangeNow(g_nextStageNo);
    }

    /// <summary>
    /// 最初と最後は処理方法変えてはいる
    /// </summary>
    /// <param name="first"></param>
    public void NextStageColor(bool firstOrEnd)
    {
        if (firstOrEnd)
        {
            _stageColor.StageColorChangeNow(g_nextStageNo + 2);
        }
        else
        {
            _stageColor.StageColorChangeNow(g_nextStageNo + 1);
        }
    }
}
