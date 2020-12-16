using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    const float PLAYER_CAMERA_DIFFERENCE = 7f;
    const float TOP_LIMIT = 5f;
    const float UNDER_LIMIT = 5f;

    const float ZOOM_IN_SPEED = 0.05f;
    const float ZOOM_IN_SIZE = 1.5f;

    const float ZOOM_OUT_SPEED = 0.08f;

    private float g_initialSize;

    [SerializeField]
    bool g_zooming;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        g_zooming = false;
        g_initialSize = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
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

    private void FixedUpdate()
    {
        
    }

    public void ZoomIn()
    {
        g_zooming = true;
    }

    public void ZoomOut()
    {
        g_zooming = false;
    }
}
