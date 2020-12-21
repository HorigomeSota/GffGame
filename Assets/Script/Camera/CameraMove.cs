using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject playerObj;
    Transform playerTransform;
    const float PLAYER_CAMERA_DIFFERENCE = 7f;
    const float TOP_LIMIT = 5f;
    const float UNDER_LIMIT = 5f;

    const float ZOOM_IN_SPEED = 0.02f;
    const float ZOOM_IN_SIZE = 1.2f;

    const float ZOOM_OUT_SPEED = 0.08f;

    private float g_initialSize;

    [SerializeField]
    bool g_zooming;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObj.transform;
        g_zooming = false;
        g_initialSize = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        if(playerObj.GetComponent<PlayerState>().GetPlayerStatus() == 5) { g_zooming = true; }
        else { g_zooming = false; }

        transform.position = new Vector3(playerTransform.position.x + PLAYER_CAMERA_DIFFERENCE, transform.position.y, transform.position.z);

        if (playerTransform.position.y - transform.position.y >= TOP_LIMIT) { transform.position = new Vector3(transform.position.x, playerTransform.position.y - TOP_LIMIT, transform.position.z); }
        if (transform.position.y - playerTransform.position.y >= UNDER_LIMIT) { transform.position = new Vector3(transform.position.x, playerTransform.position.y + UNDER_LIMIT, transform.position.z); }

        if (g_zooming)
        {
            if (GetComponent<Camera>().orthographicSize - ZOOM_IN_SPEED > g_initialSize - ZOOM_IN_SIZE && GetComponent<Camera>().orthographicSize - ZOOM_IN_SPEED > 0f)
            {
                GetComponent<Camera>().orthographicSize -= ZOOM_IN_SPEED;
            }
            else if (GetComponent<Camera>().orthographicSize - ZOOM_IN_SPEED > 0f)
            {
                GetComponent<Camera>().orthographicSize = g_initialSize - ZOOM_IN_SIZE;
            }
            else
            {
                GetComponent<Camera>().orthographicSize = 0f;
            }
        }
        else
        {
            if (GetComponent<Camera>().orthographicSize + ZOOM_OUT_SPEED < g_initialSize)
            {
                GetComponent<Camera>().orthographicSize += ZOOM_OUT_SPEED;
            }
            else
            {
                GetComponent<Camera>().orthographicSize = g_initialSize;
            }
        }
    }
}
