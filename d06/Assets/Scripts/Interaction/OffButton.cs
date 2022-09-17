using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffButton : ButtonTrigger
{
    protected override void OnClick()
    {
        GetComponent<AudioSource>().Play();
        Destroy(interactionObject);
    }
   
}
