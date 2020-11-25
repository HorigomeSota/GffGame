using System.Collections;
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

}
