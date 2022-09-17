using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSmoke : ButtonTrigger
{
    protected override void OnClick()
    {
        interactionObject.GetComponent<ParticleSystem>().Play();
    }
}
