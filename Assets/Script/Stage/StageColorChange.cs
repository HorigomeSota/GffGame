using UnityEngine;

/// <summary>
/// ステージとプレイヤーの色の組み合わせスクリプト
/// </summary>
public class StageColorChange : MonoBehaviour
{
    /// <summary>
    /// 色一覧
    /// </summary>
    public enum Colors
    {
        Blue1BFAFF = 0,
        Green23FFB5 = 1,
        Green23FF17 = 2,
        YellowF8FF26 = 3,
        YellowFFF021 = 4,
        OrangeFFB530 = 5,
        PinkFF1F91 = 6,
        PinkFF21B2 = 7,
        PurpleF215FF = 8,
        PurpleAA1BFF = 9,
        Purple761AFF = 10,
        Blue6E1BFF = 11,
        Blue4422FF = 12,
    }

    /// <summary>
    /// 色に対応したマテリアル
    /// </summary>
    [SerializeField]private Material[] _materials;

    /// <summary>
    /// 色セットするステージのオブジェクトのレンダラーと色
    /// </summary>
    [SerializeField] private Renderer _floorARenderer = default;
    [SerializeField] private Renderer _floorBRenderer = default;
    [SerializeField] private Renderer _toleranceARenderer = default;
    [SerializeField] private Renderer _toleranceBRenderer = default;
    [SerializeField] private Material[] _toleranceMaterials = new Material[2];
    [SerializeField] private Renderer _enemyARenderer = default;
    [SerializeField] private Renderer _enemyBRenderer = default;
    [SerializeField] private Renderer[] _panelARenderer = new Renderer[3];
    [SerializeField] private Renderer[] _panelBRenderer = new Renderer[3];
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private Material _playerMatA;
    [SerializeField] private Material _playerMatB;
    [SerializeField] private Color _matAColor;
    [SerializeField] private Color _matBColor;
    [SerializeField] private int _endlessmatAColor;
    [SerializeField] private int _endlessmatBColor;

    /// <summary>
    /// エンドレスの色A
    /// </summary>
    public int EndlessAColor
    {
        get { return _endlessmatAColor; }
        set { _endlessmatAColor = value;}
    }

    /// <summary>
    /// エンドレスの色B
    /// </summary>
    public int EndlessBColor
    {
        get { return _endlessmatBColor; }
        set { _endlessmatBColor = value;}
    }

    private PlayerColorChange _colorChange;

    private void Awake()
    {
        _playerObj = GameObject.FindGameObjectWithTag("Player");
        _colorChange = _playerObj.GetComponent<PlayerColorChange>();

        _materials = new Material[30];

        //Resources取得
        _materials[0] = Resources.Load<Material>("Materials/1BFAFF");
        _materials[1] = Resources.Load<Material>("Materials/23FFB5");
        _materials[2] = Resources.Load<Material>("Materials/23FF17");
        _materials[3] = Resources.Load<Material>("Materials/F8FF26");
        _materials[4] = Resources.Load<Material>("Materials/FFF021");
        _materials[5] = Resources.Load<Material>("Materials/FFB530");
        _materials[6] = Resources.Load<Material>("Materials/FF1F91");
        _materials[7] = Resources.Load<Material>("Materials/FF21B2");
        _materials[8] = Resources.Load<Material>("Materials/F215FF");
        _materials[9] = Resources.Load<Material>("Materials/AA1BFF");
        _materials[10] = Resources.Load<Material>("Materials/761AFF");
        _materials[11] = Resources.Load<Material>("Materials/6E1BFF");
        _materials[12] = Resources.Load<Material>("Materials/4422FF");
        _playerMatA = Resources.Load<Material>("Materials/PlayerMatA");
        _playerMatB = Resources.Load<Material>("Materials/PlayerMatB");

        _floorARenderer = Resources.Load<GameObject>("Prefab/Floor0").GetComponent<Renderer>();
        _floorBRenderer = Resources.Load<GameObject>("Prefab/Floor1").GetComponent<Renderer>();
        _toleranceARenderer = Resources.Load<GameObject>("Prefab/ToleranceValue0").GetComponent<Renderer>();
        _toleranceBRenderer = Resources.Load<GameObject>("Prefab/ToleranceValue1").GetComponent<Renderer>();
        _enemyARenderer = Resources.Load<GameObject>("Prefab/Enemy0").GetComponent<Renderer>();
        _enemyBRenderer = Resources.Load<GameObject>("Prefab/Enemy1").GetComponent<Renderer>();
        _panelARenderer = Resources.Load<GameObject>("Prefab/Panel0").transform.Find("Panel").GetComponentsInChildren<Renderer>();
        _panelBRenderer = Resources.Load<GameObject>("Prefab/Panel1").transform.Find("Panel").GetComponentsInChildren<Renderer>();

        EndlessAColor = 0;
        EndlessBColor = 1;
    }

    /// <summary>
    /// 色設定
    /// </summary>
    /// <param name="colorsA">色1</param>
    /// <param name="colorsB">色2</param>
    public void SetColors(Colors colorsA, Colors colorsB)
    {
        _toleranceMaterials[0] = _materials[(int)colorsA];
        _toleranceMaterials[1] = _materials[(int)colorsB];
        _floorARenderer.material = _materials[(int)colorsA];
        _floorBRenderer.material = _materials[(int)colorsB];
        _toleranceARenderer.materials = _toleranceMaterials;
        _toleranceBRenderer.materials = _toleranceMaterials;
        _enemyARenderer.material = _materials[(int)colorsA];
        _enemyBRenderer.material = _materials[(int)colorsB];
        _panelARenderer[0].material = _materials[(int)colorsA];
        _panelARenderer[1].material = _materials[(int)colorsA];
        _panelARenderer[2].material = _materials[(int)colorsA];
        _panelBRenderer[0].material = _materials[(int)colorsB];
        _panelBRenderer[1].material = _materials[(int)colorsB];
        _panelBRenderer[2].material = _materials[(int)colorsB];
        _matAColor = _materials[(int)colorsA].color;
        _matBColor = _materials[(int)colorsB].color;
    }

    /// <summary>
    /// プレイヤーの色の設定(ステージ変わるときとかに呼び出す)
    /// </summary>
    /// <param name="colorsA">色1</param>
    /// <param name="colorsB">色2</param>
    public void SetColorPlayer()
    {
        _playerMatA.color = _matAColor;
        _playerMatB.color = _matBColor;
    }
}
