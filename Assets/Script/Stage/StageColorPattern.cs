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
        Yellow = 2,
        LightGreen = 3,
        Orange = 4,
        PinkPurple = 5,
    }

    /// <summary>
    /// 色に対応したマテリアル
    /// </summary>
    private Material[] _materials = new Material[6];

    /// <summary>
    /// 色セットするステージのオブジェクト
    /// </summary>
    [SerializeField] private Renderer floorARenderer = default;
    [SerializeField] private Renderer floorBRenderer = default;
    [SerializeField] private Renderer toleranceARenderer = default;
    [SerializeField] private Renderer toleranceBRenderer = default;
    [SerializeField] private Renderer enemyARenderer = default;
    [SerializeField] private Renderer enemyBRenderer = default;
    [SerializeField] private Renderer panelARenderer = default;
    [SerializeField] private Renderer panelBRenderer = default;

    private void Awake()
    {
        //プレハブ取得
        _materials[0] = Resources.Load<Material>("Materials/Red");
        _materials[1] = Resources.Load<Material>("Materials/Blue");
        _materials[2] = Resources.Load<Material>("Materials/Yellow");
        _materials[3] = Resources.Load<Material>("Materials/LightGreen");
        _materials[4] = Resources.Load<Material>("Materials/Orange");
        _materials[5] = Resources.Load<Material>("Materials/PinkPurple");

        floorARenderer = Resources.Load<GameObject>("Prefab/Floor0").GetComponent<Renderer>();
        floorBRenderer = Resources.Load<GameObject>("Prefab/Floor1").GetComponent<Renderer>();
        toleranceARenderer = Resources.Load<GameObject>("Prefab/ToleranceValue0").GetComponent<Renderer>();
        toleranceBRenderer = Resources.Load<GameObject>("Prefab/ToleranceValue1").GetComponent<Renderer>();
        enemyARenderer = Resources.Load<GameObject>("Prefab/Enemy0").GetComponent<Renderer>();
        enemyBRenderer = Resources.Load<GameObject>("Prefab/Enemy1").GetComponent<Renderer>();
        panelARenderer = Resources.Load<GameObject>("Prefab/Panel0").GetComponent<Renderer>();
        panelBRenderer = Resources.Load<GameObject>("Prefab/Panel1").GetComponent<Renderer>();
    }

    /// <summary>
    /// 色設定
    /// </summary>
    /// <param name="colorsA">色1</param>
    /// <param name="colorsB">色2</param>
    public void SetColors(Colors colorsA, Colors colorsB)
    {
        floorARenderer.material = _materials[(int)colorsA];
        floorARenderer.material = _materials[(int)colorsB];
        toleranceARenderer.material = _materials[(int)colorsA];
        toleranceARenderer.material = _materials[(int)colorsB];
        enemyARenderer.material = _materials[(int)colorsA];
        enemyBRenderer.material = _materials[(int)colorsB];
        panelARenderer.material = _materials[(int)colorsA];
        panelBRenderer.material = _materials[(int)colorsB];
    }
}
