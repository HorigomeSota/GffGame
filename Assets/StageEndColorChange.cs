using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stageの終わりを判別するためのスクリプト
/// </summary>
public class StageEndColorChange : MonoBehaviour
{
    private GameObject _playerObject;

    private StageColorChange _stageColorChange;

    /// <summary>
    /// プレイヤーとチェックポイントの座標の差が0より小さくなった時の判定のための数字
    /// </summary>
    const float _endPointDistance=0;

    /// <summary>
    /// 現在のステージ番号を格納
    /// </summary>
    private int _stageNumber=default;

    public int StageNumber
    {
        get { return _stageNumber; }
        set { _stageNumber = value; }
    }

    private void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _stageColorChange = GameObject.FindGameObjectWithTag("StageColor").GetComponent<StageColorChange>();
    }

    private void Update()
    {
        //プレイヤーがチェックポイント超えたら
        if (transform.position.x - _playerObject.transform.position.x < _endPointDistance)
        {
            //プレイヤーの色を変更する処理を呼び出す
            _stageColorChange.SetColorPlayer();
        }
    }
}
