using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalEfect : MonoBehaviour
{
    /// <summary>
    /// 花火エフェクト青
    /// </summary>
    private GameObject fireworkBluePrefab;
    /// <summary>
    /// 花火拡散エフェクト黄
    /// </summary>
    private GameObject fireworkYellowPrfab;
    /// <summary>
    /// ゲームマネージャー
    /// </summary>
    private GameObject gameManager;
    /// <summary>
    /// ステージクリア後に表示するタイマーテキスト
    /// </summary>
    private Text resultTimerText;
   　/// <summary>
    /// タイマーテキスト
    /// </summary>
    private Text timerText;
    /// <summary>
    /// ゲーム画面のキャンバス
    /// </summary>
    private GameObject gameSceneCanvas;
    
    private StageColorChange _colorChange;

    const int efectQuantity = 9;

    const string gameManagerTag = "GameManager";

    const string timerTextTag = "TextTimer";

    const string resultTimerTextTag = "ResultTimer";

    const string gameCanvasTag = "GameCanvas";

    const string stageColorTag = "StageColor";

    const string prefabFolderName = "Prefab";

    const string particlesFolderName = "Particles";

    const string fireworkBlueName = "FireworksBlue";

    const string fireworkYellowClusterName = "FireworksYellow";

    void Start()
    {
        fireworkBluePrefab = Resources.Load<GameObject>(prefabFolderName+"/"+particlesFolderName+"/"+fireworkBlueName);
        fireworkYellowPrfab = Resources.Load<GameObject>(prefabFolderName + "/" + particlesFolderName + "/" + fireworkYellowClusterName);
        resultTimerText = GameObject.FindWithTag(resultTimerTextTag).GetComponent<Text>();
        timerText = GameObject.FindWithTag(timerTextTag).GetComponent<Text>();
        gameManager = GameObject.FindWithTag(gameManagerTag);
        gameSceneCanvas = GameObject.FindWithTag(gameCanvasTag);
        _colorChange = GameObject.FindGameObjectWithTag(stageColorTag).GetComponent<StageColorChange>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Goal());
            gameManager.GetComponent<GameManager>().timerStop = true;
        }
        _colorChange.SetColorPlayer();
    }

    IEnumerator Goal()
    {
        gameSceneCanvas.GetComponent<Animator>().SetBool("Clear", true);

        resultTimerText.text = timerText.text;

        int efectDistance = 0;

        for (int count = 0; count < efectQuantity; count++)
        {


            efectDistance += 10;

            Instantiate(fireworkBluePrefab, new Vector3(transform.position.x + efectDistance, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);


        }

        yield break;
    }
}
