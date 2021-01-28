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
        Debug.Log("stageNumber"+ stageNumber);
        switch (stageNumber)
        {
            case 0:
                _colorChange.SetColors(global::StageColorChange.Colors.Purple761AFF, global::StageColorChange.Colors.YellowFFF021);
                break;

            case 1:
                _colorChange.SetColors(global::StageColorChange.Colors.PurpleF215FF, global::StageColorChange.Colors.YellowF8FF26);
                break;

            case 2:
                _colorChange.SetColors(global::StageColorChange.Colors.Blue4422FF, global::StageColorChange.Colors.PinkFF21B2);
                break;

            case 3:
                _colorChange.SetColors(global::StageColorChange.Colors.YellowF8FF26, global::StageColorChange.Colors.PinkFF21B2);
                break;

            case 4:
                _colorChange.SetColors(global::StageColorChange.Colors.Green23FFB5, global::StageColorChange.Colors.PurpleAA1BFF);
                break;

            case 5:
                _colorChange.SetColors(global::StageColorChange.Colors.Blue1BFAFF, global::StageColorChange.Colors.PinkFF1F91);
                break;

            case 6:
                _colorChange.SetColors(global::StageColorChange.Colors.OrangeFFB530, global::StageColorChange.Colors.Blue6E1BFF);
                break;

            case 7:
                _colorChange.SetColors(global::StageColorChange.Colors.Green23FF17, global::StageColorChange.Colors.PinkFF21B2);
                break;

            case 8:
                _colorChange.SetColors(global::StageColorChange.Colors.Green23FF17, global::StageColorChange.Colors.PinkFF21B2);
                break;
        }
    }

    /// <summary>
    /// エンドレスの色
    /// </summary>
    public void StageColorChangeEndless()
    {
        _colorChange.SetColors((StageColorChange.Colors)_colorChange.EndlessAColor, (StageColorChange.Colors)_colorChange.EndlessBColor);
    }
}
