using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_audioBGMObject;
    [SerializeField]
    private GameObject m_audioSEObject;

    [SerializeField]
    private AudioSource m_audioSourceBGM;
    [SerializeField]
    private AudioSource m_audioSourceSE;


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
        m_audioSourceBGM = m_audioBGMObject.GetComponent<AudioSource>();
        m_audioSourceSE = m_audioSEObject.GetComponent<AudioSource>();
    }

    private void PlayBGM()
    {
        m_audioSourceBGM.Play();
    }

    private void PlaySE()
    {
        m_audioSourceSE.PlayOneShot(m_audioSourceSE.clip);
    }

    public void AudioStopBGM()//BGM止める
    {
        m_audioSourceBGM.Stop();
    }

    public void AudioStopSE()//SE止める
    {
        m_audioSourceSE.Stop();
    }

    public void StageBGM()//StageBGM再生
    {
        Debug.Log("BGM");
        m_audioSourceBGM.clip = m_stage;
        PlayBGM();
    }

    public void JumpSE()//JumpSE再生
    {
        m_audioSourceSE.clip = m_jump;
        PlaySE();
    }

    public void ColorChangeSE()//ColorChangeSE再生
    {
        m_audioSourceSE.clip = m_colorChange;
        PlaySE();
    }

    public void BoostSE()//BoostSE再生
    {
        m_audioSourceSE.clip = m_boost;
        PlaySE();
    }

    public void PanelSE()//PanelSE再生
    {
        m_audioSourceSE.clip = m_panel;
        PlaySE();
    }
}
