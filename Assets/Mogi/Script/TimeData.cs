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
    [SerializeField] float m_saveTime;
    private float[] g_stageTimes;
    private float g_resultTime;
    private float g_bestScore;
    private float g_scoreResult;
    int key; private float g_playingtime = 0;
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



    public void SavePlayerData()
    {
        StreamWriter writer;
        string datastr = "ScoreData";
        string jsonstr = JsonUtility.ToJson(playerData);
        writer = new StreamWriter(Application.dataPath + "/save" + datastr + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }



    public void LoadPlayerData()
    {
        string datastr = "ScoreData";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/save" + datastr + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();
        playerData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log(playerData.saveBestTimes + "のデータをロードしました");
        g_stageTimes = playerData.saveBestTimes;
        g_bestScore = playerData.BestScore;
    }
}
