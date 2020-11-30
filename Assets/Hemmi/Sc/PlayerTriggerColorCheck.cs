using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerColorCheck : MonoBehaviour
{
    private GameObject m_triggerObj;

    private int m_playerColor;

    private PlayerState m_playerState;

    // Start is called before the first frame update
    void Start()
    {
        m_playerState = GetComponent<PlayerState>();
    }

    private void Update()
    {
        //触れているオブジェクトとプレイヤーの色取得
        m_playerColor = m_playerState.GetColor();
        m_triggerObj = m_playerState.GetTriggerObj();
        if(m_triggerObj!=null) ColorCheck();

    }

    private void ColorCheck()//自分の色と、オブジェクトの色比較
    {
        switch (m_triggerObj.tag)
        {
            case "Enemy"://敵に触れたとき(色が違うと死ぬ)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {

                }
                else {
                    GetComponent<PlayerState>().DeathFlagOn();
                }//ステイトをデスにする

                break;

            case "Shortcut"://ショートカットに当たった時(同じ色だと発動)

                if (m_triggerObj.GetComponent<Shortcut>().GetColor() == m_playerColor)
                {
                    GetComponent<PlayerState>().BoostFlagOn();//ステイトをショートカットのやつにする
                }

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

    }

}
