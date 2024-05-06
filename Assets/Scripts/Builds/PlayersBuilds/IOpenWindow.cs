using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface that open window, when object is clicked
public interface IOpenWindow
{
    int WindowIndex { get; } // Index of a window in UI controller
    void OnMouseDown();
}
