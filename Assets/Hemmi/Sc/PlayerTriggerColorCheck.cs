using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerColorCheck : MonoBehaviour
{
    GameObject m_triggerObj;
    int m_playerColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetTriggerObj(GameObject trigger,int color)//触れているオブジェクトとプレイヤーの色取得
    {
        m_triggerObj = trigger;
        m_playerColor = color;
    }

    private void ColorCheck()//自分の色と、オブジェクトの色比較
    {
        switch (m_triggerObj.tag)
        {
            case "Enemy"://敵に触れたとき(色が違うと死ぬ)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {

                }
                else { }//ステイトをデスにする

                break;

            case "Shortcut"://ショートカットに当たった時(同じ色だと発動)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {
                    //ステイトをショートカットのやつにする
                }

                break;

            case "Panel"://パネルに当たった時(同じ色だと発動)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {
                    //ステイトをパネルスピードアップにする
                }

                break;

            case "ToleranceValue"://許容値に当たった時(同じ色だと発動)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {
                    //ここじゃ使わないや
                }

                break;

            case "Floor"://フロアに当たった時(同じ色だとmove,違う色だとスピードダウン)

                if (m_triggerObj.GetComponent<Enemy>().GetColor() == m_playerColor)
                {
                    //ステイトをmoveに変更
                }
                else
                {
                    //ステイトをスピードダウンに変更
                }

                break;



        }

    }

}
