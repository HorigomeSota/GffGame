using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartPhoneInput :MonoBehaviour,IInput
{
    /// <summary>trueの時、ジャンプする </summary>
    private bool m_jumpCheck = false;

    /// <summary>trueの時、色を変える</summary>
    private bool m_colorCheck = false;

    /// <summary>Sceneナンバー</summary>
    private int g_sceneNum = 0;
   

    /// <summary>カメラを取得</summary>
    private Camera camera_object;

    /// <summary>レイキャストが当たったものを取得する入れ物</summary>
    private RaycastHit m_hit;


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
                //オブジェクト名を取得して変数に入れる
                string objectName = m_hit.collider.gameObject.name;
                ObjectCheck(objectName);
                
            }
        }
    }


    private void ObjectCheck(string name)
    {
        switch (name)
        {
            //右側がタップされたとき　m_jumpCheck　をtrue
            case ("RightTap"):

                m_jumpCheck = true;

                break;

            //左側がタップされたとき　m_colorCheck　をtrue
            case ("LeftTap"):

                m_colorCheck = true;

                break;
                
            case ("ToTitle"):

                g_sceneNum = 0;

                break;

            case ("ToStageSelect"):

                g_sceneNum = 1;

                break;

           
            case ("ToGame_Clone"):

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
        return m_jumpCheck;
    }

    public bool ColorCheck()
    {
        return m_colorCheck;
    }

    public void Reset()
    {
        m_colorCheck = false;
        m_jumpCheck = false;
    }


}
