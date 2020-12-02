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

    [SerializeField]
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


    // 音声再生用スクリプト
    // Start is called before the first frame update
    private void Awake()
    {
        m_audioSources = new AudioSource[2];
        m_audioSources=GetComponents<AudioSource>();
    }

    private void PlayBGM()
    {
        m_audioSources[0].Play();
        Debug.Log("BGMなった");
    }

    private void PlaySE()
    {

        m_audioSources[1].PlayOneShot(m_audioSources[1].clip);
        Debug.Log("SEなった");

    }

    /// <summary>
    /// 各クラスから、音を鳴らしたいときに呼び出す。stringは、接頭語を抜いたクラス名でお願いします
    /// </summary>
    /// <param name="audio"></param>
    public void PlayClip(string audio)
    {
        switch (audio)
        {
            case "Jump":
                m_audioSources[1].clip = m_jump;
                audioType = AudioType.SE;
                break;

            case "Stage":
                m_audioSources[0].clip = m_stage;
                audioType = AudioType.BGM;
                break;

            case "ColorChange":
                m_audioSources[1].clip = m_colorChange;
                audioType = AudioType.SE;
                break;

            case "Boost":
                m_audioSources[1].clip = m_boost;
                audioType = AudioType.SE;
                break;

            case "PanelSpeedUp":
                m_audioSources[1].clip = m_panel;
                audioType = AudioType.SE;
                break;
        }

        if (audioType == AudioType.BGM)
        {
            PlayBGM();
        }
        else if (audioType == AudioType.SE)
        {
            PlaySE();
        }

    }


}
