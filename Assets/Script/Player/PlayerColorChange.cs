using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    [SerializeField] private Material _materialA;
    [SerializeField] private Material _materialB;

    public Material MaterialA
    {
        get { return _materialA; }
        set { _materialA = value; }
    }

    public Material MaterialB
    {
        get { return _materialB; }
        set { _materialB = value; }
    }

    [SerializeField]
    private GameObject m_audioManagerObject;

    private PlayerState m_playerState;
    private Renderer m_renderer;

    private PlayerTriggerColorCheck m_TriggerColorCheck;

    [SerializeField]
    private AudioManager m_audioManager;

    private void Start()
    {
        m_TriggerColorCheck = GetComponent<PlayerTriggerColorCheck>();
        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //マテリアル参照
        _materialA = Resources.Load<Material>("Materials/PlayerMatA");
        _materialB = Resources.Load<Material>("Materials/PlayerMatB");

        //インスタンス化
        m_playerState = GetComponent<PlayerState>();
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (m_playerState.GetColorChangeFlag())//cloroChangeのフラグがたっているか確認
        {
            m_TriggerColorCheck.ColorCheck();
            if (m_playerState.ColorChange())
            {
               m_audioManager.PlayClip("ColorChange", 0);
            }

            //色情報取得
            if (m_playerState.GetColor() == 0)
            {
                //色（見た目）変える
                m_renderer.material = _materialA;
            }
            else
            {
                //色（見た目）変える
                m_renderer.material = _materialB;
            }
        }
    }

    public void ResetColor()
    {
        //色（見た目）変える
        m_renderer.material = _materialA;
    }
}
