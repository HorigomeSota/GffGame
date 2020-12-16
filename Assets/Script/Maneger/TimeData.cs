using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TimeData : MonoBehaviour
{


    [System.Serializable]
    public class PlayerData
    {
        public float[] saveBestTimes;//配列の番号でステージ分けしている
        public float[] saveSecondTimes;//配列の番号でステージ分けしている
        public float[] saveThirdTimes;//配列の番号でステージ分けしている
        public float BestScore;
    }
    PlayerData playerData = new PlayerData();

    [SerializeField]
    StageOrder m_stageOrder;
    [SerializeField] int m_saveStageNumber=default;
    [SerializeField] float m_saveTime;
    private float[] g_stageThirdTimes;
    private float[] g_stageSecondTimes;
    private float[] g_stageBestTimes;
    private float g_resultTime;
    private float g_bestScore;
    private float g_scoreResult;
    int key = default; 

    private string datastr = "ScoreData";
    
    private float g_playingtime = 0;

    private void Start()
    {
        m_stageOrder = GameObject.Find("StageCreate").transform.GetComponent<StageOrder>();
    }

    /// <summary>
    /// 記録比較用メソッド
    /// </summary>
    private void TimeCompare()
    {
        /*
        g_resultTime = g_playingtime;
        if (g_stageBestTimes[key] > g_playingtime)
        {
            g_stageBestTimes[key] = g_playingtime;
        }
        */
        if (g_playingtime < playerData.saveBestTimes[m_stageOrder.GetStageNumber()])//もしタイムが最高記録なら
        {
            playerData.saveThirdTimes[m_stageOrder.GetStageNumber()] = playerData.saveSecondTimes[m_stageOrder.GetStageNumber()];
            playerData.saveSecondTimes[m_stageOrder.GetStageNumber()] = playerData.saveBestTimes[m_stageOrder.GetStageNumber()];
            playerData.saveBestTimes[m_stageOrder.GetStageNumber()] = g_playingtime;
        }
        //二番目だったら
        else if (playerData.saveBestTimes[m_stageOrder.GetStageNumber()] < g_playingtime || g_playingtime < playerData.saveSecondTimes[m_stageOrder.GetStageNumber()])
        {
            playerData.saveThirdTimes[m_stageOrder.GetStageNumber()] = playerData.saveSecondTimes[m_stageOrder.GetStageNumber()];
            playerData.saveSecondTimes[m_stageOrder.GetStageNumber()] = g_playingtime;
        }
        //三番目だったら
        else if(playerData.saveSecondTimes[m_stageOrder.GetStageNumber()] < g_playingtime || g_playingtime < playerData.saveThirdTimes[m_stageOrder.GetStageNumber()])
        {
            playerData.saveThirdTimes[m_stageOrder.GetStageNumber()] = g_playingtime;
        }

    }
    /// <summary>
    /// 直近のゲームのTimeを取得用
    /// </summary>
    /// <returns></returns>
    public float GetResult()
    {
        return g_resultTime;
    }

    /// <summary>
    /// プレイ中に時間を順次記録していく
    /// </summary>
    /// <returns></returns>
    public float PlayNowTimeSave(float time)
    {
        g_playingtime += time;
        return g_playingtime;
    }

    /// <summary>
    /// UIから読み込む用
    /// </summary>
    /// <returns></returns>
    public float GetPlayNow()
    {
        return g_playingtime;
    }


    /// <summary>
    /// ScoreDataを保存
    /// </summary>
    public void SavePlayerData()
    {
        StreamWriter writer;
        playerData.BestScore = g_playingtime;
        LoadPlayerData();
        TimeCompare();
        string jsonstr = JsonUtility.ToJson(playerData);
        
        writer = new StreamWriter(Application.dataPath + "/save" +".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }


    /// <summary>
    /// ScoreDataを読み込み
    /// </summary>
    public void LoadPlayerData()
    {
        
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save"  + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();
        playerData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き

        g_stageBestTimes = playerData.saveBestTimes;
        g_bestScore = playerData.BestScore;
    }

    public float GetBestTime(int stageNumber)
    {
        LoadPlayerData();
        return playerData.saveBestTimes[stageNumber];
    }

    public float GetSecondTime(int stageNumber)
    {
        LoadPlayerData();
        return playerData.saveSecondTimes[stageNumber];
    }

    public float GetThirdTime(int stageNumber)
    {
        LoadPlayerData();
        return playerData.saveThirdTimes[stageNumber];
    }

}
