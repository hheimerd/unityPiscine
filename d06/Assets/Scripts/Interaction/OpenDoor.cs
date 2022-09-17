using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : ButtonTrigger
{
    protected override void OnClick()
    {
        var audio = GetComponent<AudioSource>();
        if (_player.haveKey)
        {
            audio.pitch = 1;
            audio.Play();
            interactionObject.GetComponent<SliderDoor>().isOpen = true;
            interactionObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            audio.pitch = 0.45f;
            audio.Play();
        }
        
    }
}
