using UnityEngine;
using UnityEngine.UI;

public class LogDisplay : MonoBehaviour
{
    public Text message = null;

    private float fps;

    private void Update()
    {
        fps = 1f / Time.deltaTime;
        Debug.Log(fps);
    }


    private void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDestroy()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        message.text = logText;
    }
}