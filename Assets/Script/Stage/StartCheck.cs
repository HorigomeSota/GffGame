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

    const string gameManagerTag = "GameManager";

    const string timerTag = "Timer";

    const string gameCanvasTag = "GameCanvas";

    const string PLAYERTAG = "Player";

    private void Start()
    {
        timerObject = GameObject.FindGameObjectWithTag(timerTag);
        gameManager = GameObject.FindWithTag(gameManagerTag);
        gameSceneCanvas = GameObject.FindWithTag(gameCanvasTag);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYERTAG)
        {
            //タイマーリセット
            timerObject.GetComponent<Timer>().TimerReset();
            //チェックポイント更新
            gameManager.GetComponent<GameManager>().SetCheckPoint(this.gameObject);
        }
    }
}
