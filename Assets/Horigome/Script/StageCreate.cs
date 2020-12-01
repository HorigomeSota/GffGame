using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    [SerializeField]
    GameObject floorAObj;
    const int FLOOR_A = 10;
    [SerializeField]
    GameObject floorBObj;
    const int FLOOR_B = 11;
    [SerializeField]
    GameObject toleranceAObj;
    const int TOLERANCE_A = 20;
    [SerializeField]
    GameObject toleranceBObj;
    const int TOLERANCE_B = 21;
    [SerializeField]
    GameObject enemyAObj;
    const int ENEMY_A = 30;
    [SerializeField]
    GameObject enemyBObj;
    const int ENEMY_B = 31;

    [SerializeField]
    const int FLOORA_ENEMYA = 1030;
    [SerializeField]
    const int FLOORA_ENEMYB = 1031;
    [SerializeField]
    const int FLOORB_ENEMYA = 1130;
    [SerializeField]
    const int FLOORB_ENEMYB = 1131;

    #region GameObject panelAObj
    [SerializeField]
    GameObject panelA0Obj;
    const int PANEL_A_0 = 4000;
    [SerializeField]
    GameObject panelA15Obj;
    const int PANEL_A_15 = 4015;
    [SerializeField]
    GameObject panelA30Obj;
    const int PANEL_A_30 = 4030;
    [SerializeField]
    GameObject panelA45Obj;
    const int PANEL_A_45 = 4045;
    [SerializeField]
    GameObject panelA60Obj;
    const int PANEL_A_60 = 4060;
    [SerializeField]
    GameObject panelA75Obj;
    const int PANEL_A_75 = 4075;
    [SerializeField]
    GameObject panelA90Obj;
    const int PANEL_A_90 = 4090;
    #endregion
    #region GameObject panelBObj
    [SerializeField]
    GameObject panelB0Obj;
    const int PANEL_B_0 = 4100;
    [SerializeField]
    GameObject panelB15Obj;
    const int PANEL_B_15 = 4115;
    [SerializeField]
    GameObject panelB30Obj;
    const int PANEL_B_30 = 4130;
    [SerializeField]
    GameObject panelB45Obj;
    const int PANEL_B_45 = 4145;
    [SerializeField]
    GameObject panelB60Obj;
    const int PANEL_B_60 = 4160;
    [SerializeField]
    GameObject panelB75Obj;
    const int PANEL_B_75 = 4175;
    [SerializeField]
    GameObject panelB90Obj;
    const int PANEL_B_90 = 4190;
    #endregion
    [SerializeField]
    GameObject shortcutObj;
    const int SHORTCUT = 50;

    [SerializeField]
    GameObject checkPointObj;
    const int CHECKPOINT = 100;

    GameObject checkPointObject;

    private string g_stage;

    public void SetStageName(string stageName)
    {
        g_stage = stageName;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void CreateMap(int[,] arrays, int hgt, int wid)
    {
        for (int i = 0; i < hgt; i++)
        {
            for (int j = 0; j < wid; j++)
            {
                switch (arrays[i, j])
                {
                    case FLOOR_A:
                        Instantiate(floorAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case FLOOR_B:
                        Instantiate(floorBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case TOLERANCE_A:
                        Instantiate(toleranceAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case TOLERANCE_B:
                        Instantiate(toleranceBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case ENEMY_A:
                        Instantiate(enemyAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case ENEMY_B:
                        Instantiate(enemyBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case SHORTCUT:
                        Instantiate(shortcutObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;

                    #region case PANEL_A
                    case PANEL_A_0:
                        Instantiate(panelA0Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_15:
                        Instantiate(panelA15Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_30:
                        Instantiate(panelA30Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_45:
                        Instantiate(panelA45Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_60:
                        Instantiate(panelA60Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_75:
                        Instantiate(panelA75Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_A_90:
                        Instantiate(panelA90Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    #endregion
                    #region case PANEL_B
                    case PANEL_B_0:
                        Instantiate(panelB0Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_15:
                        Instantiate(panelB15Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_30:
                        Instantiate(panelB30Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_45:
                        Instantiate(panelB45Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_60:
                        Instantiate(panelB60Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_75:
                        Instantiate(panelB75Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case PANEL_B_90:
                        Instantiate(panelB90Obj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    #endregion

                    case CHECKPOINT:
                        checkPointObject = Instantiate(checkPointObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;

                    case FLOORA_ENEMYA:
                        Instantiate(floorAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        Instantiate(enemyAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORA_ENEMYB:
                        Instantiate(floorAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        Instantiate(enemyBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORB_ENEMYA:
                        Instantiate(floorBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        Instantiate(enemyAObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                    case FLOORB_ENEMYB:
                        Instantiate(floorBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        Instantiate(enemyBObj, new Vector3(transform.position.x + j, transform.position.y + hgt - 1 - i, transform.position.z), Quaternion.identity);
                        break;
                }
            }
        }
        transform.position = new Vector3(checkPointObject.transform.position.x + 1, checkPointObject.transform.position.y, checkPointObject.transform.position.z);
    }

    public void Generate()
    {
        g_stage = GetComponent<StageOrder>().GetNextStage();

        Debug.Log(g_stage);

        if (g_stage == null) { g_stage = "Stage01"; }
        GetComponent<StageMapCSVread>().PrepareStage(g_stage);
        CreateMap(GetComponent<StageMapCSVread>().GetStageMapDatas(), GetComponent<StageMapCSVread>().GetHeight(), GetComponent<StageMapCSVread>().GetWidth());

    }
}
