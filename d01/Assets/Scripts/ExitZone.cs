using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    public Player targetPlayer;
    [NonSerialized] public bool isActive = false;
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.Equals(targetPlayer.gameObject))
        {
            isActive = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.Equals(targetPlayer.gameObject))
        {
            isActive = true;
        }
    }
}
