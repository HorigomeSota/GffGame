﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    bool JumpCheck();
    bool ColorCheck();
    /// <summary>
    /// bool値を　false　にする
    /// </summary>
    void Reset();

    /// <returns>0=title,1=stegeSelect,2=game,3=retry</returns>
    int SceneCheck();

    /// <summary>選択したオブジェクト取得 </summary>
    GameObject ChoiceObj();

}
