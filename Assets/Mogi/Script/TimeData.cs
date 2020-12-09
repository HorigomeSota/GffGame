using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TimeData : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public float[] saveBestTimes;
        public float BestScore;
    }
    PlayerData playerData = new PlayerData();
    [SerializeField] int m_saveStageNumber=default;
    [SerializeField] float m_saveTime;
    private float[] g_stageTimes;
    private float g_resultTime;
    private float g_bestScore;
    private float g_scoreResult;
    int key = default; 

    private string datastr = "ScoreData";
    
    private float g_playingtime = 0;

    /// <summary>
    /// 最高記録を比較してセット
    /// </summary>
    public void TimeCompare()
    {
        g_resultTime = g_playingtime;
        if (g_stageTimes[key] > g_playingtime)
        {
            g_stageTimes[key] = g_playingtime;
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
        Debug.Log(g_playingtime);
        playerData.BestScore = g_playingtime;
        string jsonstr = JsonUtility.ToJson(playerData);
        writer = new StreamWriter(Application.dataPath + "/save" +m_saveStageNumber+ ".json", false);
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
        Debug.Log("/save" + m_saveStageNumber + datastr + ".json");
        reader = new StreamReader(Application.dataPath + "/save" + m_saveStageNumber + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();
        playerData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log(playerData.saveBestTimes + "のデータをロードしました");
        g_stageTimes = playerData.saveBestTimes;
        g_bestScore = playerData.BestScore;
    }

    public float GetBestScore()
    {
        return g_bestScore;
    }

}
