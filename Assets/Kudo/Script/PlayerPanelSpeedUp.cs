using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelSpeedUp : MonoBehaviour
{

    /// <summary>
    /// Panelの向き
    /// </summary>
    private Vector3 m_panelForce;
    /// <summary>
    /// プレイヤーのRigidbody
    /// </summary>
    private Rigidbody m_PlayerRigidbody;
    /// <summary>
    /// スピード
    /// </summary>
    [SerializeField] private float m_speed;


    private void Start()
    {
        m_PlayerRigidbody = GetComponent<Rigidbody>();

        //ここで向きを取得する
        if (m_panelForce == new Vector3(0, 0, 0))
            m_panelForce = new Vector3(0, 1, 0);

        if (m_speed == 0)
            m_speed = 10;

    }

    private void Update()
    {
        if (Input.anyKeyDown) PanelSpeedUp();
    }

    private void PanelSpeedUp()
    {
        m_PlayerRigidbody.AddForce(m_panelForce * m_speed, ForceMode.Impulse);
    }


}
