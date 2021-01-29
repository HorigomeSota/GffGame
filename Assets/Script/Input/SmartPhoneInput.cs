using System.Collections;
using UnityEngine;

public class SmartphoneInput : MonoBehaviour,IInput
{
    Vector3 mouseDiff;

    Vector3 mousePos;     // 最初にタッチ(左クリック)した地点の情報を入れる

    /// <summary>trueの時、ジャンプする </summary>
    private bool g_jumpCheck = false;

    /// <summary>trueの時、色を変える</summary>
    private bool g_colorCheck = false;

    /// <summary>Sceneナンバー</summary>
    private int g_sceneNum = 0;


    /// <summary>カメラを取得</summary>
    private Camera camera_object;

    /// <summary>レイキャストが当たったものを取得する入れ物</summary>
    private RaycastHit m_hit;

    private GameObject g_hitObj;

    private float tolerance = default;

    private bool once = default;

    private string objectName = default;

    private void Start()
    {
        tolerance = 25f;
    }

    private void Update()
    {
        // Moveメソッドを常時呼び出す
        Move();
    }


    private void ObjectCheck(string name)
    {
        switch (name)
        {
            
            case ("ToTitle"):

                g_sceneNum = 0;

                break;

            case ("ToStageSelect"):

                g_sceneNum = 1;

                break;


            case ("ToGame(Clone)"):

                g_sceneNum = 2;

                break;

            case ("Retry"):

                g_sceneNum = 3;

                break;

            case ("Escape"):

                g_sceneNum = 4;

                break;
            default:
                break;
        }
    }

    public int ResetSceneNum()
    {
        g_sceneNum = -1;
        return g_sceneNum;
    }

    void Move()
    {
        camera_object = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        // マウス左クリック(画面タッチ)が行われたら
        if (Input.GetMouseButtonDown(0))
        {
            // タッチした位置を代入
            mousePos = Input.mousePosition;

            //マウスのポジションを取得してRayに代入
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

            //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            if (Physics.Raycast(ray, out m_hit))
            {
                //オブジェクトを取得して変数に入れる
                g_hitObj = m_hit.collider.gameObject;

                //オブジェクト名を取得して変数に入れる
                objectName = g_hitObj.name;
            }
            else
            {
                objectName = null;
            }
            once = true;
        }
        if (Input.GetMouseButton(0))
        {
            // ベクトルの引き算を行い、現在のタッチ位置とその１フレーム前のタッチ位置との差分を方向として代入
            mouseDiff = Input.mousePosition - mousePos;

            if (mouseDiff.y>tolerance&& once)
            {

                g_jumpCheck = true;
                once = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseDiff.y <= tolerance)
            {
                g_colorCheck = true;
            }

            if (mouseDiff.x<=tolerance&& mouseDiff.x >= -tolerance)
            {
                ObjectCheck(objectName);
            }
        }
    }
    public int SceneCheck()
    {
        return g_sceneNum;
    }

    public bool JumpCheck()
    {
        return g_jumpCheck;
    }

    public bool ColorCheck()
    {
        return g_colorCheck;
    }

    public void Reset()
    {
        g_colorCheck = false;
        g_jumpCheck = false;
    }

    public GameObject ChoiceObj()
    {
        return g_hitObj;
    }
}