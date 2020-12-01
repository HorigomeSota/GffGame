using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private enum AudioType
    {
        none,
        BGM,
        SE
    }

    AudioType audioType=AudioType.none;


    /*
    [SerializeField]
    private GameObject m_audioBGMObject;
    [SerializeField]
    private GameObject m_audioSEObject;

    [SerializeField]
    private AudioSource m_audioSourceBGM;
    [SerializeField]
    private AudioSource m_audioSourceSE;
    */
    private AudioSource[] m_audioSources;

    [SerializeField]
    private AudioClip m_jump;
    [SerializeField]
    private AudioClip m_stage;
    [SerializeField]
    private AudioClip m_colorChange;
    [SerializeField]
    private AudioClip m_boost;
    [SerializeField]
    private AudioClip m_panel;

    [SerializeField]
    private bool g_playOneShot;

    // 音声再生用スクリプト
    // Start is called before the first frame update
    private void Awake()
    {
        m_audioSources = new AudioSource[2];
        m_audioSources=GetComponents<AudioSource>();
        g_playOneShot = false;
        //m_audioSourceBGM = m_audioBGMObject.GetComponent<AudioSource>();
        //m_audioSourceSE = m_audioSEObject.GetComponent<AudioSource>();
    }

    /*
    private void PlayBGM()
    {
        m_audioSourceBGM.Play();
        Debug.Log("BGMなった");
    }
    */

    private void PlaySE()
    {
        if (!g_playOneShot)//連続でならないように
        {
            m_audioSources[1].PlayOneShot(m_audioSources[1].clip);
            Debug.Log("SEなった");
            g_playOneShot = true;
        }
        
    }



    /*

    public void StageBGM()//StageBGM再生
    {
        Debug.Log("BGM");
        m_audioSourceBGM.clip = m_stage;
        PlayBGM();
    }

    */

    public void PlayClip(string audio)
    {
        switch (audio)
        {
            case "jump":
                break;

            case "stage":
                break;
        }

        if (audioType == AudioType.BGM)
        {

        }
        else if (audioType == AudioType.SE)
        {

        }


    }

}
