using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBGMs : MonoBehaviour
{
    [SerializeField]
    private AudioClip customBGM=default;

    private GameObject m_audioManagerObj;

    AudioManager m_audioManager;

    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクトFind
        m_audioManagerObj = GameObject.FindGameObjectWithTag("AudioManager");

        //インスタンス化
        m_audioManager = m_audioManagerObj.GetComponent<AudioManager>();
    }

    public void OnClick()
    {
        Debug.Log("押した");
        m_audioManager.PlayClip("Tap", 0);
        m_audioManager.SetCustomBGM(customBGM);
    }

    
}
