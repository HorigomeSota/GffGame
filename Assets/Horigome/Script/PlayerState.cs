using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //現在の色
    [SerializeField]　private int color=1;
    /// <summary>Colorを変える</summary>
    public void ColorChange()
    {
        if (color == 0) { color = 1; }
        else { color = 0; }
        g_colorChange = false;
        g_colorChangeNow = true;
    }
    /// <summary>プレイヤーの色取得</summary>
    /// <returns>0か1</returns>
    public int GetColor() { return color; }

    //現在のスピード
    private float speed;
    /// <summary>プレイヤーのスピード取得</summary>
    /// <returns>スピード</returns>
    public float GetSpeed() { return speed; }

    //触れているゲームオブジェクト
    private GameObject g_triggerObject;
    /// <summary>プレイヤーに触れているゲームオブジェクトを渡す</summary>
    /// <param name="triggerObj">触れているゲームオブジェクト</param>
    public void SetTriggerObj(GameObject triggerObj) { g_triggerObject = triggerObj; }
    /// <summary>プレイヤーに触れているゲームオブジェクトを取得</summary>
    /// <returns>触れているゲームオブジェクト</returns>
    public GameObject GetTriggerObj() { return g_triggerObject; }

    #region フラグ
    //死フラグ
    private bool g_death = false;
    /// <summary>プレイヤーの死んだフラグをオンにする</summary>
    public void DeathFlagOn()
    {
        //ブースト中は死なない
        if (!g_boost) { g_death = true; }
    }
    /// <summary>プレイヤーの死んだフラグ取得</summary>
    /// <returns>true=死んでる false=生きてる</returns>
    public bool GetDeathFlag() { return g_death; }

    //ジャンプフラグ
    private bool g_jump = false;
    /// <summary>プレイヤーのジャンプフラグをオンにする</summary>
    public void JumpFlagOn()
    {
        if (!g_boost &&
            g_playerStatus != PlayerStatus.fall &&
            g_playerStatus != PlayerStatus.cSpeeddown)
        { g_jump = true; }
    }
    /// <summary>プレイヤーのジャンプフラグをオフにする</summary>
    public void JumpFlagOff() { g_jump = false; }
    /// <summary>プレイヤーのジャンプフラグ取得</summary>
    /// <returns>true=ジャンプしたい</returns>
    public bool GetJumpFlag() { return g_jump; }

    //ブーストフラグ
    private bool g_boost = false;
    /// <summary>プレイヤーのブーストフラグをオンにする</summary>
    public void BoostFlagOn() { g_boost = true; }
    /// <summary>プレイヤーのブーストフラグをオフにする</summary>
    public void BoostFlagOff() { g_boost = false; }
    /// <summary>プレイヤーのブーストフラグ取得</summary>
    /// <returns>true=ブーストしたい</returns>
    public bool GetBoostFlag() { return g_boost; }

    //パネルスピードアップフラグ
    private bool g_pSpeedUp = false;
    /// <summary>プレイヤーのパネルスピードアップフラグをオンにする</summary>
    public void PanelSpeedUpFlagOn() { if (!g_boost) { g_pSpeedUp = true; } }
    /// <summary>プレイヤーのパネルスピードアップフラグをオフにする</summary>
    public void PanelSpeedUpFlagOff() { g_pSpeedUp = false; }
    /// <summary>プレイヤーのパネルスピードアップフラグ取得</summary>
    /// <returns>true=パネルスピードアップしたい</returns>
    public bool GetPanelSpeedUpFlag() { return g_pSpeedUp; }

    //カラーチェンジフラグ
    private bool g_colorChange = false;
    /// <summary>プレイヤーのカラーチェンジフラグをオンにする</summary>
    public void ColorChangeFlagOn() { g_colorChange = true; }
    /// <summary>プレイヤーのカラーチェンジフラグ取得</summary>
    /// <returns>true=カラーチェンジしたい</returns>
    public bool GetColorChangeFlag() { return g_colorChange; }

    //カラーチェンジ中フラグ
    [SerializeField] private bool g_colorChangeNow = false;

    /// <summary>プレイヤーのカラーチェンジnowフラグをオフにする</summary>
    public void ColorChangeNowFlagOff() { g_colorChangeNow = false; }
    /// <summary>プレイヤーのカラーチェンジnowフラグ取得</summary>
    /// <returns>true=カラーチェンジしたからダッシュするか確認して</returns>
    public bool GetColorChangeNowFlag() { return g_colorChangeNow; }
    #endregion

    #region プレイヤーステータス
    private enum PlayerStatus
    {
        move,
        fall,
        cSpeedup,
        cSpeeddown,
        none
    }

    [SerializeField] PlayerStatus g_playerStatus = PlayerStatus.none;
    /// <summary>プレイヤーステータスをmoveにする</summary>
    public void Move() { if (!g_boost) g_playerStatus = PlayerStatus.move; }
    /// <summary>プレイヤーステータスをfallにする</summary>
    public void Fall() { if (!g_boost) g_playerStatus = PlayerStatus.fall; }
    /// <summary>プレイヤーステータスをcSpeedupにする</summary>
    public void ColorSpeedUp() { if (!g_boost) g_playerStatus = PlayerStatus.cSpeedup; }
    /// <summary>プレイヤーステータスをcSpeeddownにする</summary>
    public void ColorSpeedDown() { if (!g_boost) g_playerStatus = PlayerStatus.cSpeeddown; }
    /// <summary>プレイヤーステータスをnoneにする</summary>
    public void None() { g_playerStatus = PlayerStatus.none; }
    /// <summary>プレイヤーステータス取得</summary>
    /// <returns>0=move,1=fall,2=cSpeedup,3=cSpeeddown,4=none</returns>
    public int GetPlayerStatus() { return (int)g_playerStatus; }
    #endregion

    private void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.x;

    }
}
