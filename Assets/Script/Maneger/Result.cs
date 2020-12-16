using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    PlayerState m_playerState;
    TimeData m_timeData;

    private bool m_gameOver=true;

    // Start is called before the first frame update
    void Start()
    {
        m_playerState = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerState>();
        m_timeData = GameObject.FindGameObjectWithTag("Data").transform.GetComponent<TimeData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerState.GetDeathFlag())
        {

            GameOver();
            
        }
    }

    //GameOver処理かく(今はデータ保存の疎通確認したいので未完成,そのうちだれかやろう)
    private void GameOver()
    {
        if (m_gameOver)
        {
            m_timeData.SavePlayerData();
            m_gameOver = false;
        }

    }
}
