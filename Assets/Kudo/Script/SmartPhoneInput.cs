using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneInput :MonoBehaviour,IInput
{
    /// <summary>trueの時、ジャンプする </summary>
    private bool m_jumpCheck = false;

    /// <summary>trueの時、色を変える</summary>
    private bool m_colorCheck = false;

    /// <summary>カメラを取得</summary>
    public Camera camera_object;

    /// <summary>レイキャストが当たったものを取得する入れ物</summary>
    private RaycastHit hit; 


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                Debug.Log(objectName); //オブジェクト名をコンソールに表示
            }
        }
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

    //右側がタップされたとき　m_jumpCheck　をtrue
    public void RightScreenTap()
    {
        m_jumpCheck = true;
    }

    //左側がタップされたとき　m_colorCheck　をtrue
    public void LeftScreenTap()
    {

        m_colorCheck = true;
     }


    

}
