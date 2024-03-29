﻿using UnityEngine;


public class StageCreate : MonoBehaviour
{
    [SerializeField]
    GameObject floorAObj= default;
    const int FLOOR_A = 10;
    [SerializeField]
    GameObject floorBObj= default;
    const int FLOOR_B = 11;
    [SerializeField]
    GameObject toleranceAObj= default;
    const int TOLERANCE_A = 20;
    [SerializeField]
    GameObject toleranceBObj = default;
    const int TOLERANCE_B = 21;
    [SerializeField]
    GameObject enemyAObj = default;
    const int ENEMY_A = 30;
    [SerializeField]
    GameObject enemyBObj = default;
    const int ENEMY_B = 31;

    [SerializeField]
    const int FLOORA_ENEMYA = 1030;
    [SerializeField]
    const int FLOORA_ENEMYB = 1031;
    [SerializeField]
    const int FLOORB_ENEMYA = 1130;
    [SerializeField]
    const int FLOORB_ENEMYB = 1131;

    //パネルの角度
    [SerializeField]
    const int panelAngle0 = 0;
    [SerializeField]
    const int panelAngle15 = 15;
    //パネルの角度=0
    [SerializeField]
    const int panelAngle30 = 30;
    //パネルの角度=0
    [SerializeField]
    const int panelAngle45 = 45;
    //パネルの角度=0
    [SerializeField]
    const int panelAngle60 = 60;
    //パネルの角度=0
    [SerializeField]
    const int panelAngle75 = 75;
    //パネルの角度=0
    [SerializeField]
    const int panelAngle90 = 90;

    #region GameObject panelAObj
    [SerializeField]
    GameObject panelAObjPfb = default;
    const int PANEL_A_0 = 4000;
    
    const int PANEL_A_15 = 4015;
    
    const int PANEL_A_30 = 4030;
    
    const int PANEL_A_45 = 4045;
    
    const int PANEL_A_60 = 4060;
    
    const int PANEL_A_75 = 4075;
   
    const int PANEL_A_90 = 4090;
    #endregion
    #region GameObject panelBObj
    [SerializeField]
    GameObject panelBObjPfb = default;
    const int PANEL_B_0 = 4100;
    
    const int PANEL_B_15 = 4115;
    
    const int PANEL_B_30 = 4130;
    
    const int PANEL_B_45 = 4145;
    
    const int PANEL_B_60 = 4160;
   
    const int PANEL_B_75 = 4175;
    
    const int PANEL_B_90 = 4190;
    #endregion
    [SerializeField]
    GameObject shortcutObj = default;
    const int SHORTCUT = 50;

    [SerializeField]
    GameObject checkPointPfb = default;
    const int CHECKPOINT = 100;
    GameObject checkPointObject = default;

    private GameObject startObj = default;
    const int START = 200;

    private GameObject goalObj = default;
    const int GOAL = 300;

    private GameObject lastGoalObj = default;
    const int LASTGOAL = 400;

    GameObject panelBObj = default;
    GameObject panelAObj = default;

    const float prefabScaleX = 1f;
    const float prefabScaleY = 1f;

    private bool _intervalSet = default;

    /// <summary>
    /// ステージオーダースクリプト
    /// </summary>
    StageOrder _stageOrder;

    /// <summary>
    /// CSVread読み込みスクリプト
    /// </summary>
    StageMapCSVread _stageMapCSVread;

    private void Awake()
    {
        //プレハブ取得
        floorAObj = Resources.Load<GameObject>("Prefab/Floor0");
        floorBObj = Resources.Load<GameObject>("Prefab/Floor1");
        toleranceAObj = Resources.Load<GameObject>("Prefab/ToleranceValue0");
        toleranceBObj = Resources.Load<GameObject>("Prefab/ToleranceValue1");
        enemyAObj = Resources.Load<GameObject>("Prefab/Enemy0");
        enemyBObj = Resources.Load<GameObject>("Prefab/Enemy1");
        panelAObjPfb = Resources.Load<GameObject>("Prefab/Panel0");
        panelBObjPfb = Resources.Load<GameObject>("Prefab/Panel1");
        shortcutObj = Resources.Load<GameObject>("Prefab/Shortcut");
        checkPointPfb = Resources.Load<GameObject>("Prefab/CheckPoint");
        startObj = Resources.Load<GameObject>("Prefab/Start");
        goalObj = Resources.Load<GameObject>("Prefab/Goal");
        lastGoalObj= Resources.Load<GameObject>("Prefab/LastGoal");

        _stageOrder = GetComponent<StageOrder>();
        _stageMapCSVread = GetComponent<StageMapCSVread>();
        SetIntervalSetOn();
    }

    //CSVの名前
    private string g_stage;
    /// <summary>
    /// ステージの名前入れる
    /// </summary>
    /// <param name="stageName">ステージ名（csvファイル名）</param>
    public void SetStageName(string stageName)
    {
        g_stage = stageName;
    }
    /// <summary>
    /// ステージ、ブロック生成
    /// </summary>
    /// <param name="arrays">csv</param>
    /// <param name="hgt">高さ</param>
    /// <param name="wid">長さ</param>
    /// <param name="stageOrInterval">stage=0,interval=1</param>
    void CreateMap(int[,] arrays, int hgt, int wid, int stageOrInterval)
    {
        for (int i = 0; i < hgt; i++)
        {
            for (int j = 0; j < wid; j++)
            {
                float prefabPositionX = transform.position.x + j * prefabScaleX;
                float prefabPositionY = (transform.position.y + hgt - 1 - i) * prefabScaleY;

                switch (arrays[i, j])
                {
                    case FLOOR_A:
                        Instantiate(floorAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case FLOOR_B:
                        Instantiate(floorBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case TOLERANCE_A:
                        Instantiate(toleranceAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(90,-90,0));
                        break;
                    case TOLERANCE_B:
                        Instantiate(toleranceBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(90, 90, 0));
                        break;
                    case ENEMY_A:
                        Instantiate(enemyAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case ENEMY_B:
                        Instantiate(enemyBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case SHORTCUT:
                        Instantiate(shortcutObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;

                    #region case PANEL_A
                    case PANEL_A_0:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle0)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle0);

                        break;
                    case PANEL_A_15:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX , prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle15)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle15);

                        break;
                    case PANEL_A_30:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle30)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle30);

                        break;
                    case PANEL_A_45:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle45)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle45);

                        break;
                    case PANEL_A_60:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle60)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle60);

                        break;
                    case PANEL_A_75:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle75)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle75);

                        break;
                    case PANEL_A_90:
                        panelAObj = Instantiate(panelAObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle90)) as GameObject;
                        panelAObj.transform.GetComponent<Panel>().SetRotation(panelAngle90);

                        break;
                    #endregion
                    #region case PANEL_B
                    case PANEL_B_0:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle0)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle0);
                        break;
                    case PANEL_B_15:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle15)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle15);
                        break;
                    case PANEL_B_30:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle30)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle30);
                        break;
                    case PANEL_B_45:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle45)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle45);
                        break;
                    case PANEL_B_60:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle60)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle60);
                        break;
                    case PANEL_B_75:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle75)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle75);
                        break;
                    case PANEL_B_90:
                        panelBObj = Instantiate(panelBObjPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.Euler(0, 0, panelAngle90)) as GameObject;
                        panelBObj.transform.GetComponent<Panel>().SetRotation(panelAngle90);
                        break;
                    #endregion

                    case CHECKPOINT:
                        checkPointObject = Instantiate(checkPointPfb, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;

                    case FLOORA_ENEMYA:
                        Instantiate(floorAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        Instantiate(enemyAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORA_ENEMYB:
                        Instantiate(floorAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        Instantiate(enemyBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORB_ENEMYA:
                        Instantiate(floorBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        Instantiate(enemyAObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORB_ENEMYB:
                        Instantiate(floorBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        Instantiate(enemyBObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case START:
                        Instantiate(startObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case GOAL:
                        Instantiate(goalObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                    case LASTGOAL:
                        Instantiate(lastGoalObj, new Vector3(prefabPositionX, prefabPositionY, transform.position.z), Quaternion.identity);
                        break;
                }
            }
        }
        if (stageOrInterval == 0)
        {
            GetComponent<StageMapCSVread>().MapCsvRead(g_stage);
        }
        transform.position = new Vector3(checkPointObject.transform.position.x + 1, checkPointObject.transform.position.y, checkPointObject.transform.position.z);
        GetComponent<StageMapCSVread>().MapCsvRead(g_stage);
    }

    /// <summary>
    /// ステージ生成
    /// </summary>
    public void Generate()
    {
        /*if (_stageOrder.GetEndlessNow())
        {
            _stageOrder.EndlessStageColor();
        }
        else */
        _stageOrder.NextStageColor();

        g_stage = _stageOrder.GetNextStage();

        if (_intervalSet)
        {
            CreateMap(_stageMapCSVread.GetIntervalMapDatas(), _stageMapCSVread.GetIntervalHeight(), _stageMapCSVread.GetIntervalWidth(), 1);
        }
        CreateMap(_stageMapCSVread.GetStageMapDatas(), _stageMapCSVread.GetHeight(), _stageMapCSVread.GetWidth(), 0);
    }

    public GameObject GetStartPosition()
    {
        return startObj;
    }
    public void SetIntervalSetOff()
    {
        _intervalSet = false;
    }

    public void SetIntervalSetOn()
    {
        _intervalSet = true;
    }
}
