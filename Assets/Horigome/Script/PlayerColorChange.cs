using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    [SerializeField] private Material materialBlue;
    [SerializeField] private Material materialRed;


    [SerializeField]
    private GameObject m_audioManagerObject;

    private PlayerState m_playerState;
    private Renderer m_renderer;

    [SerializeField]
    private AudioManager m_audioManager;

    private void Start()
    {

        //ゲームオブジェクトFind
        m_audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");

        //マテリアル参照
        materialBlue = Resources.Load<Material>("Materials/Blue");
        materialRed = Resources.Load<Material>("Materials/Red");

        //インスタンス化
        m_playerState = GetComponent<PlayerState>();
        m_audioManager = m_audioManagerObject.GetComponent<AudioManager>();
        m_renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (m_playerState.GetColorChangeFlag())//cloroChangeのフラグがたっているか確認
        {
            m_playerState.ColorChange();

            m_audioManager.PlayClip("ColorChange",0);

            //色情報取得
            if (m_playerState.GetColor() == 0)
            {
                Debug.Log("げっとからー"+m_playerState.GetColor());
                //色（見た目）変える
                m_renderer.material = materialBlue;
            }
            else
            {
                Debug.Log("げっとからー" + m_playerState.GetColor());
                //色（見た目）変える
                m_renderer.material = materialRed;
            }
            
            
        }
    }
}
