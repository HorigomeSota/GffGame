using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    //画像入れるスクリプト
    [SerializeField]
    private GameObject _backgroundsprite1 = default;
    [SerializeField]
    private GameObject _backgroundsprite2 = default;
    [SerializeField]
    private GameObject _backgroundsprite3 = default;
    [SerializeField]
    private GameObject _backgroundsprite4 = default;
    private GameObject playerObj=default;
    private PlayerState playerState;
    private float _playerspeed = default;
    [SerializeField]
    private float[] _resetposition = default;
    [SerializeField]
    private float[] _deadposition = new float[] { 0, 0, 0, 0 };




    private void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        playerState = playerObj.GetComponent<PlayerState>();
        _resetposition = new float[4];
        _resetposition[0] = _backgroundsprite1.transform.localPosition.x;
        _resetposition[1] = _backgroundsprite2.transform.localPosition.x;
        _resetposition[2] = _backgroundsprite3.transform.localPosition.x;
        _resetposition[3] = _backgroundsprite4.transform.localPosition.x;
    }



    private void Update()
    {
        _playerspeed = playerState.GetSpeed();
        if (_playerspeed>0)
        {
            _backgroundsprite1.GetComponent<Rigidbody>().velocity = new Vector3(-_playerspeed, 0, 0);
            _backgroundsprite2.GetComponent<Rigidbody>().velocity = new Vector3(-_playerspeed, 0, 0);
            _backgroundsprite3.GetComponent<Rigidbody>().velocity = new Vector3(-_playerspeed, 0, 0);
            _backgroundsprite4.GetComponent<Rigidbody>().velocity = new Vector3(-_playerspeed, 0, 0);
        }
        else
        {
            _playerspeed = 0;
            _backgroundsprite1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _backgroundsprite2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _backgroundsprite3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _backgroundsprite4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (_backgroundsprite1.GetComponent<Transform>().localPosition.x <= _deadposition[0])
        {
            _backgroundsprite1.GetComponent<Transform>().localPosition = new Vector3(_resetposition[0], _backgroundsprite1.GetComponent<Transform>().localPosition.y, _backgroundsprite1.GetComponent<Transform>().localPosition.z);
        }
        if (_backgroundsprite2.GetComponent<Transform>().localPosition.x <= _deadposition[1])
        {
            _backgroundsprite2.GetComponent<Transform>().localPosition = new Vector3(_resetposition[1], _backgroundsprite2.GetComponent<Transform>().localPosition.y, _backgroundsprite2.GetComponent<Transform>().localPosition.z);
        }
        if (_backgroundsprite3.GetComponent<Transform>().localPosition.x <= _deadposition[2])
        {
            _backgroundsprite3.GetComponent<Transform>().localPosition = new Vector3(_resetposition[2], _backgroundsprite3.GetComponent<Transform>().localPosition.y, _backgroundsprite3.GetComponent<Transform>().localPosition.z);
        }
        if (_backgroundsprite4.GetComponent<Transform>().localPosition.x <= _deadposition[3])
        {
            _backgroundsprite4.GetComponent<Transform>().localPosition = new Vector3(_resetposition[3], _backgroundsprite4.GetComponent<Transform>().localPosition.y, _backgroundsprite4.GetComponent<Transform>().localPosition.z);
        }
    }
}
