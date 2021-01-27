using UnityEngine;

public class StageColor : MonoBehaviour
{
    private StageColorChange _colorChange;

    private void Awake()
    {
        _colorChange = GetComponent<StageColorChange>();
    }

    /// <summary>
    /// ステージごとに決められた色に変える
    /// </summary>
    /// <param name="stageNumber">ステージ番号</param>
    public void StageColorChangeNow(int stageNumber)
    {
        switch (stageNumber)
        {
            case 0:
                _colorChange.SetColors(global::StageColorChange.Colors.Blue, global::StageColorChange.Colors.Red);
                break;

            case 1:
                _colorChange.SetColors(global::StageColorChange.Colors.Yellow, global::StageColorChange.Colors.Orange);
                break;

            case 2:
                _colorChange.SetColors(global::StageColorChange.Colors.PinkPurple, global::StageColorChange.Colors.LightGreen);
                break;

            case 3:
                _colorChange.SetColors(global::StageColorChange.Colors.Blue, global::StageColorChange.Colors.Yellow);
                break;

            case 4:
                _colorChange.SetColors(global::StageColorChange.Colors.Red, global::StageColorChange.Colors.LightGreen);
                break;

            case 5:
                _colorChange.SetColors(global::StageColorChange.Colors.Orange, global::StageColorChange.Colors.PinkPurple);
                break;

            case 6:
                _colorChange.SetColors(global::StageColorChange.Colors.Yellow, global::StageColorChange.Colors.LightGreen);
                break;

            case 7:
                _colorChange.SetColors(global::StageColorChange.Colors.PinkPurple, global::StageColorChange.Colors.LightBlue);
                break;
        }
    }
}
