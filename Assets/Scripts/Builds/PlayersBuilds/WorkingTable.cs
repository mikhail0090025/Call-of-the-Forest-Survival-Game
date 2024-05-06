using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingTable : Build, IOpenWindow
{
    public int WindowIndex { get => 3; }

    public void OnMouseDown()
    {
        WindowsManager.WMinstance.windows[WindowIndex].ChangeState(true);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
