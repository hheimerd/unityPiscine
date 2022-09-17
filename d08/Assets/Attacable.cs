using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacable : MonoBehaviour
{

    public float hp = 1;
    
    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            var animator = GetComponent<Animator>();
            if (animator)
                animator.SetBool("IsDead", true);
            Destroy(this);
        }

    }
}
