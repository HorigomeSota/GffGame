using UnityEngine;

public class StartCheck : MonoBehaviour
{
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameObject gameManager; 
    /// <summary>
    /// Timer格納オブジェクト
    /// </summary>
    GameObject timerObject;

    private Timer timer = default;

    const string gameManagerTag = "GameManager";

    const string timerTag = "Timer";

    const string PLAYERTAG = "Player";

    private void Start()
    {
        timerObject = GameObject.FindGameObjectWithTag(timerTag);
        gameManager = GameObject.FindWithTag(gameManagerTag);
        timer = timerObject.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYERTAG)
        {
            //タイマーリセット
            timer.TimerReset();
            timer.StageStart();
            gameManager.GetComponent<GameManager>().SetTimeStop(false);
            //チェックポイント更新
            gameManager.GetComponent<GameManager>().SetCheckPoint(gameObject);
        }
    }
}
