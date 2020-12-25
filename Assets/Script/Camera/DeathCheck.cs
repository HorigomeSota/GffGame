using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    [SerializeField, Header("GameOverUI")]
    GameObject gameOversceneObj = default;
    [SerializeField, Header("PLayer")]
    GameObject playerObj = default;

    void Update()
    {
        if (playerObj.GetComponent<PlayerState>().GetDeathFlag())
        {
            gameOversceneObj.SetActive(true);
        }
    }
}
