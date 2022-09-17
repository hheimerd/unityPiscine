using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Collider detectZone;
    public AttackController attackController;
    public Attacable attacable;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("Player"))
        {
            attackController.SetTarget(other.GetComponent<Attacable>());
        }
    }

    public bool IsDied()
    {
        return attacable.hp <= 0;
    }
    private void FixedUpdate()
    {
        if (IsDied())
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("Attack", false);
            transform.position -= transform.up * Time.deltaTime;
            Destroy(attackController);
        }
    }
}
