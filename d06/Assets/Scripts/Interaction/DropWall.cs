using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWall : ButtonTrigger
{
    protected override void OnClick()
    {
        var rb = GetComponent<Rigidbody>();
        // rb.AddForce(-transform.right * 100);
        transform.Rotate(-transform.forward * 20);
        Destroy(this);
    }
}
