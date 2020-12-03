using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Transform m_cameraTrans;
    Transform m_playerTrans;
    Vector3 m_cameraVec;

    private void Start()
    {
        m_cameraTrans = GetComponent<Transform>();
        m_cameraVec = GetComponent<Transform>().position;

        m_playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        //	cameraTrans.position = playerTrans.position + cameraVec;
        m_cameraTrans.position = Vector3.Lerp(m_cameraTrans.position, m_playerTrans.position + m_cameraVec, 2.0f * Time.deltaTime);
    }
}
