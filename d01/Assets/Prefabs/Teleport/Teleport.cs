using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject TeleportOut;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = TeleportOut.transform.position;
    }
}
