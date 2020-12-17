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

    AudioType m_audioType=AudioType.none;

    [SerializeField]
    private AudioSource[] m_audioSources;

    [SerializeField]
    private AudioClip m_jump;//ジャンプSE

    [SerializeField]
    private AudioClip m_colorChange;//カラーチェンジSE
    [SerializeField]
    private AudioClip m_boost;//ブーストSE
    [SerializeField]
    private AudioClip m_speedUp;//スピードアップSE
    [SerializeField]
    private AudioClip m_uiClick;//UI押した音SE
    [SerializeField]
    private AudioClip m_uiCancel;//キャンセルした音,戻る音
    [SerializeField]
    private AudioClip[] m_stage;//ステージBGM
    [SerializeField]
    private AudioClip m_title;//タイトルBGM
    [SerializeField]
    private AudioClip m_stageSelecte;//ステージセレクト画面,設定画面BGM
    [SerializeField]
    private AudioClip m_customBGM = default;//カスタムBGM

    private bool m_defaultBGM;


    // 音声再生用スクリプト
    // Start is called before the first frame update
    private void Awake()
    {
        m_stage = new AudioClip[5];
        m_defaultBGM = true;

        //AudioClip参照
        m_stage[0] = Resources.Load<AudioClip>("Sound/BGM/Stage/Stage1");
        m_stage[1] = Resources.Load<AudioClip>("Sound/BGM/Stage/Stage2");
        m_title = Resources.Load<AudioClip>("Sound/BGM/Title");
        m_stageSelecte = Resources.Load<AudioClip>("Sound/BGM/Menu");
        m_jump = Resources.Load<AudioClip>("Sound/SE/Jump");
        m_colorChange = Resources.Load<AudioClip>("Sound/SE/ColorChange");
        m_boost = Resources.Load<AudioClip>("Sound/SE/Boost");
        m_speedUp = Resources.Load<AudioClip>("Sound/SE/SpeedUp");
        m_uiClick = Resources.Load<AudioClip>("Sound/SE/Tap");

        //ゲームオブジェクトFind

        m_audioSources = new AudioSource[2];

        //インスタンス化
        m_audioSources=GetComponents<AudioSource>();
        PlayClip("Stage1", 1);
    }

    private void PlayBGM()
    {
        m_audioSources[1].Play();
        //Debug.Log("BGMなった");
    }

    private void PlaySE()
    {

        m_audioSources[0].PlayOneShot(m_audioSources[0].clip);

    }

    /// <summary>
    /// 各クラスから、音を鳴らしたいときに呼び出す。stringは、接頭語(Playerとか)を抜いたクラス名でお願いします。typeはSEなら0BGMなら1
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
                    break;

                case "ColorChange":
                    m_audioSources[type].clip = m_colorChange;
                    break;

                case "Boost":
                    m_audioSources[type].clip = m_boost;
                    break;

                case "SpeedUp":
                    m_audioSources[type].clip = m_speedUp;
                    break;

                case "Tap":
                    m_audioSources[type].clip = m_uiClick;
                    break;
            }
            m_audioType = AudioType.SE;
        }
        else if (type == 1&&m_defaultBGM)
        {
            
            switch (audio)
            {
                case "Custom":
                    break;

                case "Stage1":
                    m_audioSources[type].clip = m_stage[0];
                    break;

                case "Stage2":
                    m_audioSources[type].clip = m_stage[1];
                    break;

                case "Title":
                    m_audioSources[type].clip = m_title;
                    break;

                case "StageSelecte":
                    m_audioSources[type].clip = m_stageSelecte;
                    break;
            }
            m_audioType = AudioType.BGM;
        }
        

        if (m_audioType == AudioType.BGM)
        {
            PlayBGM();
        }
        else if (m_audioType == AudioType.SE)
        {
            PlaySE();
        }

    }

    /// <summary>
    /// defaultBGMをオンにする(最初から決まっているBGMを再生する
    /// </summary>
    public void DefaultBGMON()
    {
        m_defaultBGM = true;
    }

    /// <summary>
    /// defaultBGMをオフにする(カスタムで決めたBGMを再生する
    /// </summary>
    public void DefaultBGMOFF()
    {
        m_defaultBGM = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customBGM"></param>
    public void SetCustomBGM(AudioClip customBGM)
    {
        m_customBGM = customBGM;
    }
    /*
    public bool GetDefaultBGM()
    {
        return defaultBGM;
    }
    */
}
