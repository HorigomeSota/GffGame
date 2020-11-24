using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSpeedUp : MonoBehaviour
{
    
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

       

        if (m_speed == 0)
            m_speed = 10;

    }

    private void Update()
    {
        if (Input.anyKeyDown) ColorSpeedUp();
    }

    private void ColorSpeedUp()
    {
        m_PlayerRigidbody.AddForce(Vector3.right * m_speed, ForceMode.Impulse);
    }

}
