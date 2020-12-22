using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerColorCheck : MonoBehaviour
{
    private GameObject m_triggerObj;

    private Transform m_triggerObjBeforeTransform;

    private int m_playerColor;

    private PlayerState m_playerState;
    private Triggers m_triggers;

    // Start is called before the first frame update
    void Start()
    {
        m_playerState = GetComponent<PlayerState>();
        m_triggers = GetComponent<Triggers>();
    }



    private void Update()
    {
        //触れているオブジェクトとプレイヤーの色取得
        
        m_triggerObj = m_playerState.GetTriggerObj();
        
        if(m_triggerObj!=null&&m_triggerObj.transform!= m_triggerObjBeforeTransform) ColorCheck();
        if (m_triggers.GetFlore() != null) //フロアに触れているかどうか見る
        {
            GameObject flore = m_triggers.GetFlore();
            m_playerColor = m_playerState.GetColor();
            m_playerState.FloreFlagON();

            if (flore.GetComponent<Floor>().GetColor() == m_playerColor)
            {
                GetComponent<PlayerState>().Move();

            }
            else
            {
                GetComponent<PlayerState>().ColorSpeedDown();
            }

        }
        else m_playerState.FloreFlagOFF();
    }

    /// <summary>
    /// カラーチェンジした時にも呼ぶ
    /// </summary>
    public void ColorCheck()//自分の色と、オブジェクトの色比較。一つのオブジェクトでは一回のみ判定するようにした
    {
        m_playerColor = m_playerState.GetColor();
        if (m_triggerObj != null)
        {
            switch (m_triggerObj.tag)
            {
                case "FallDeath":
                    GetComponent<PlayerState>().DeathFlagOn();
                    break;

                case "Enemy"://敵に触れたとき(色が違うと死ぬ)

                    if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                    {
                        GetComponent<PlayerState>().Move();//ステイトをmoveに変更
                    }
                    else
                    {
                        GetComponent<PlayerState>().DeathFlagOn();
                    }//ステイトをデスにする

                    break;

                case "Shortcut"://ショートカットに当たった時(同じ色だと発動)

                   
                   
                     GetComponent<PlayerState>().BoostFlagOn();//ステイトをショートカットのやつにする


                    break;

                case "Panel"://パネルに当たった時(同じ色だと発動)

                    if (m_triggerObj.GetComponent<Panel>().GetColor() == m_playerColor)
                    {
                        GetComponent<PlayerState>().PanelSpeedUpFlagOn();//ステイトをパネルスピードアップにする




                    }

                    break;
                /*
            case "ToleranceValue"://許容値に当たった時(同じ色だと発動)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {
                    //ここじゃ使わないや
                }

                break;
                */
                case "Floor"://フロアに当たった時(同じ色だとmove,違う色だとスピードダウン)

                    if (m_triggerObj.GetComponent<Floor>().GetColor() == m_playerColor)
                    {
                        GetComponent<PlayerState>().Move();//ステイトをmoveに変更


                    }
                    else
                    {

                        GetComponent<PlayerState>().ColorSpeedDown();//ステイトをスピードダウンに変更
                    }

                    break;



            }
            m_triggerObjBeforeTransform = m_triggerObj.transform;

        }

    }

        

}
