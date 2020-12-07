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
    private AudioClip[] m_stage;
    [SerializeField]
    private AudioClip m_colorChange;
    [SerializeField]
    private AudioClip m_boost;
    [SerializeField]
    private AudioClip m_speedUp;
    [SerializeField]
    private AudioClip m_uiClick;

    private bool defaultBGM;


    // 音声再生用スクリプト
    // Start is called before the first frame update
    private void Awake()
    {
        m_stage = new AudioClip[5];
        defaultBGM = true;

        //AudioClip参照
        m_stage[0] = Resources.Load<AudioClip>("Sound/BGM/Stage1");
        m_stage[1] = Resources.Load<AudioClip>("Sound/BGM/Stage2");
        m_jump = Resources.Load<AudioClip>("Sound/SE/Jump");
        m_colorChange = Resources.Load<AudioClip>("Sound/SE/ColorChange");
        m_boost = Resources.Load<AudioClip>("Sound/SE/Boost");
        m_speedUp = Resources.Load<AudioClip>("Sound/SE/SpeedUp");
        m_uiClick = Resources.Load<AudioClip>("Sound/SE/SpeedUp");

        //ゲームオブジェクトFind

        m_audioSources = new AudioSource[2];

        //インスタンス化
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
    /// 各クラスから、音を鳴らしたいときに呼び出す。stringは、接頭語を抜いたクラス名でお願いします。typeはSEなら0BGMなら1
    /// </summary>
    /// <param name="audio"></param>
    public void PlayClip(string audio ,int type)
    {
        if (type == 0)
        {
            switch (audio)
            {
                case "Jump":
                    m_audioSources[type].clip = m_jump;
                    audioType = AudioType.SE;
                    break;

                case "ColorChange":
                    m_audioSources[type].clip = m_colorChange;
                    audioType = AudioType.SE;
                    break;

                case "Boost":
                    m_audioSources[type].clip = m_boost;
                    audioType = AudioType.SE;
                    break;

                case "SpeedUp":
                    m_audioSources[type].clip = m_speedUp;
                    audioType = AudioType.SE;
                    break;

            }
        }
        else if (type == 1&&defaultBGM)
        {
            
            switch (audio)
            {
                case "Stage1":
                    m_audioSources[type].clip = m_stage[0];
                    audioType = AudioType.BGM;
                    break;

                case "Stage2":
                    m_audioSources[type].clip = m_stage[1];
                    audioType = AudioType.BGM;
                    break;
            }
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

    /// <summary>
    /// defaultBGMをオンにする(最初から決まっているBGMを再生する
    /// </summary>
    public void DefaultBGMON()
    {

    }

    /// <summary>
    /// defaultBGMをオフにする(カスタムで決めたBGMを再生する
    /// </summary>
    public void DedaultBGMOFF()
    {

    }
}
