using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInput : MonoBehaviour, IInput
{ /// <summary>trueの時、ジャンプする </summary>
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

    private void Update()
    {
        camera_object = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        //マウスがクリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            //マウスのポジションを取得してRayに代入
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

            //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            if (Physics.Raycast(ray, out m_hit))
            {
                //オブジェクトを取得して変数に入れる
                g_hitObj = m_hit.collider.gameObject;

                //オブジェクト名を取得して変数に入れる
                string objectName = g_hitObj.name;

                ObjectCheck(objectName);

            }


        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            g_jumpCheck = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            g_colorCheck = true;
        }
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
