using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Animal
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        //base.agent.SetDestination(new Vector3(140, 40, 170));
        base.GoToPoint(new Vector3(152, 40, 183));
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }
}
