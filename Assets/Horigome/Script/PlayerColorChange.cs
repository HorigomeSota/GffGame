using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    [SerializeField] private Material materialBlue;
    [SerializeField] private Material materialRed;


    [SerializeField]
    private GameObject audioManagerObject;

    private PlayerState m_playerState;
    private Renderer m_renderer;

    [SerializeField]
    private AudioManager m_audioManager;

    private void Start()
    {
        m_playerState = GetComponent<PlayerState>();
        m_audioManager = audioManagerObject.GetComponent<AudioManager>();
        m_renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (m_playerState.GetColorChangeFlag())//cloroChangeのフラグがたっているか確認
        {
            m_playerState.ColorChange();

            m_audioManager.PlayClip("ColorChange");

            //色情報取得
            if (m_playerState.GetColor() == 0)
            {
                //色（見た目）変える
                m_renderer.material = materialBlue;
            }
            else
            {
                //色（見た目）変える
                m_renderer.material = materialRed;
            }
            
            
        }
    }
}
