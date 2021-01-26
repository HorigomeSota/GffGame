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
    /// <summary>
    /// ゲーム画面のキャンバス
    /// </summary>
    private GameObject gameSceneCanvas;

    private Timer timer = default;

    const string gameManagerTag = "GameManager";

    const string timerTag = "Timer";

    const string gameCanvasTag = "GameCanvas";

    const string PLAYERTAG = "Player";

    private void Start()
    {
        timerObject = GameObject.FindGameObjectWithTag(timerTag);
        gameManager = GameObject.FindWithTag(gameManagerTag);
        gameSceneCanvas = GameObject.FindWithTag(gameCanvasTag);
        timer = timerObject.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYERTAG)
        {
            print("no");
            //タイマーリセット
            timer.TimerReset();
            timer.StageStart();
            gameManager.GetComponent<GameManager>().timerStop = false;
            //チェックポイント更新
            gameManager.GetComponent<GameManager>().SetCheckPoint(this.gameObject);
        }
    }
}
