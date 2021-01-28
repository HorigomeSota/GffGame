using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
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

    private string datastr = "ScoreData";
    
    private float g_playingtime = 0;
    private const float _defaultBestTime = 9999.0f;
    private const int _numberOfStage = 12;

    private void Start()
    {
        m_stageOrder = GameObject.Find("StageCreate").transform.GetComponent<StageOrder>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&Application.isEditor)
        {
            ResetPlayerData();
        }
    }

    /// <summary>
    /// 記録比較用メソッド
    /// </summary>
    private void TimeCompare()
    {
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
        else if (playerData.saveSecondTimes[m_stageOrder.GetStageNumber()] < g_playingtime || g_playingtime < playerData.saveThirdTimes[m_stageOrder.GetStageNumber()])
        {
            playerData.saveThirdTimes[m_stageOrder.GetStageNumber()] = g_playingtime;
        }
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

    public void ResetTimer()
    {
        g_playingtime = 0;
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
        StartCoroutine(LoadPlayerData());
        TimeCompare();
        string jsonstr = JsonUtility.ToJson(playerData);
        string textFileName = "save.json";

        string path = null;

        DeviceType deviceType;

        deviceType = SystemInfo.deviceType;


        if (deviceType == DeviceType.Desktop)
        {
            path = Application.dataPath + "/StreamingAssets" + "/" + textFileName;
        }
        else if (deviceType == DeviceType.Handheld)
        {

            path = "jar:file://" + Application.dataPath + "!/assets" + "/" + textFileName;
        }
        writer = new StreamWriter(path, false);
        writer.Write(jsonstr);
        print(jsonstr);
        writer.Flush();
        writer.Close();
    }

    /// <summary>
    /// ビルド前に走らせる用タイム初期化メソッド。必ず実行すること
    /// </summary>
    private void ResetPlayerData()
    {
        StreamWriter writer;
        StartCoroutine(LoadPlayerData());
        for (int i=0;i<_numberOfStage; i++)
        {
            playerData.saveBestTimes[i] = _defaultBestTime;
        }
        string jsonstr = JsonUtility.ToJson(playerData);
        writer = new StreamWriter(Application.dataPath + "/save" + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    /// <summary>
    /// ScoreDataを読み込み
    /// </summary>
    public  IEnumerator LoadPlayerData()
    {
        string textFileName = "save.json";

        string path = null;

        DeviceType deviceType;

        deviceType = SystemInfo.deviceType;


        if (deviceType == DeviceType.Desktop)
        {
            path = Application.dataPath + "/StreamingAssets" + "/" + textFileName;
        }
        else if (deviceType == DeviceType.Handheld)
        {

            path = "jar:file://" + Application.dataPath + "!/assets" + "/" + textFileName;
        }
        UnityWebRequest unityWebRequest;

        unityWebRequest = UnityWebRequest.Get(path);

        yield return unityWebRequest.SendWebRequest();

        print(unityWebRequest.downloadHandler.text);

        playerData = JsonUtility.FromJson<PlayerData>(unityWebRequest.downloadHandler.text); // ロードしたデータで上書き

        g_stageBestTimes = playerData.saveBestTimes;
        g_bestScore = playerData.BestScore;

        yield break;
    }

    public float GetBestTime(int stageNumber)
    {
        StartCoroutine(LoadPlayerData());
        return playerData.saveBestTimes[stageNumber];
    }

    public float GetSecondTime(int stageNumber)
    {
        StartCoroutine(LoadPlayerData());
        return playerData.saveSecondTimes[stageNumber];
    }

    public float GetThirdTime(int stageNumber)
    {
        StartCoroutine(LoadPlayerData());
        return playerData.saveThirdTimes[stageNumber];
    }
}
