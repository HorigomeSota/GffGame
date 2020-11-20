using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Input
{
    bool JumpCheck();
    bool ColorCheck();
    /// <summary>
    /// bool値を　false　にする
    /// </summary>
    void Reset();

}
