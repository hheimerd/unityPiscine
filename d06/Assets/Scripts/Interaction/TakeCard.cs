using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCard : ButtonTrigger
{
    protected override void OnClick()
    {
        GetComponent<AudioSource>().Play();
        _player.haveKey = true;
        Destroy(gameObject);
    }
}
