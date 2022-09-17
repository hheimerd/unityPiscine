using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float damage = 10;
    public ParticleSystem collisionEffect;
    private void OnCollisionEnter(Collision other)
    {
        if (collisionEffect)
            collisionEffect.Emit(1);
        InvokeRepeating(nameof(SelfDestroy), 0.6f, 1);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
