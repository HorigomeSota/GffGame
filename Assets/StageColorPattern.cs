using UnityEngine;

/// <summary>
/// ステージとプレイヤーの色の組み合わせスクリプト
/// </summary>
public class StageColorPattern : MonoBehaviour
{
    /// <summary>
    /// 色一覧
    /// </summary>
    public enum Colors
    {
        Red = 0,
        Blue = 1,
        Yellow=2,
        LightGreen=3,
        Orange=4,
        PinkPurple=5,
    }

    /// <summary>
    /// 色に対応したマテリアル
    /// </summary>
    private Material[] _materials = new Material[6];

    /// <summary>
    /// 色セットするステージのオブジェクト
    /// </summary>
    [SerializeField] private GameObject floorAObj = default;
    [SerializeField] private GameObject floorBObj = default;
    [SerializeField] private GameObject toleranceAObj = default;
    [SerializeField] private GameObject toleranceBObj = default;
    [SerializeField] private GameObject enemyAObj = default;
    [SerializeField] private GameObject enemyBObj = default;

    //ステージとのプレイヤーの色
    private Colors _colorA;
    private Colors _colorB;

    /// <summary>
    /// 色設定
    /// </summary>
    /// <param name="colorsA">色1</param>
    /// <param name="colorsB">色2</param>
    public void SetColors(Colors colorsA,Colors colorsB)
    {
        
    }
}
