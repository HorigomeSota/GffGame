using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    //現在の色
    private int color;
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

    #region フラグ
    //死フラグ
    private bool g_death = false;
    /// <summary>プレイヤーの死んだフラグをオンにする</summary>
    public void DeathFlagOn() { g_death = true; }
    /// <summary>プレイヤーの死んだフラグ取得</summary>
    /// <returns>true=死んでる false=生きてる</returns>
    public bool GetDeathFlag() { return g_death; }

    //ジャンプフラグ
    private bool g_jump = false;
    /// <summary>プレイヤーのジャンプフラグをオンにする</summary>
    public void JumpFlagOn() { g_jump = true; }
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
    public void PanelSpeedUpFlagOn() { g_pSpeedUp = true; }
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
    private bool g_colorChangeNow = false;

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
        cSpeeddown
    }

    PlayerStatus g_playerStatus = PlayerStatus.fall;
    /// <summary>プレイヤーステータスをmoveにする</summary>
    public void Move() { g_playerStatus = PlayerStatus.move; }
    /// <summary>プレイヤーステータスをfallにする</summary>
    public void Fall() { g_playerStatus = PlayerStatus.fall; }
    /// <summary>プレイヤーステータスをcSpeedupにする</summary>
    public void ColorSpeedUp() { g_playerStatus = PlayerStatus.cSpeedup; }
    /// <summary>プレイヤーステータスをcSpeeddownにする</summary>
    public void ColorSpeedDown() { g_playerStatus = PlayerStatus.cSpeeddown; }
    /// <summary>プレイヤーステータス取得</summary>
    /// <returns>0=move,1=fall,2=cSpeedup,3=cSpeeddown</returns>
    public int GetPlayerStatus() { return (int)g_playerStatus; }
    #endregion

    private void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.x;
    }
}
