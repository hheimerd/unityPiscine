using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float attackDistance = 2;
    public float damage = 1;
    public float attackReloadTime = 1;
    public Animator animator;

    private Attacable target;
    private bool canAttack= true;

    private void Start()
    {
        InvokeRepeating(nameof(ReloadAttack), 0, attackReloadTime);
    }

    private void ReloadAttack()
    {
        canAttack = true;
    }

    public void SetTarget(Attacable newTarget)
    {
        target = newTarget;
    }

    private void TryAttack()
    {
        Debug.Log("Attack");
        if (!canAttack) return;
        
        var distance = agent.remainingDistance;
        if (distance > attackDistance) return;
        
        target.TakeDamage(damage);
        animator.SetBool("Attack", true);

        if (target.hp <= 0)
        {
            target = null;
        }

        Invoke(nameof(SetAttackFalse), 0.3f);
        canAttack = false;
    }

    void SetAttackFalse()
    {
        animator.SetBool("Attack", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        agent.SetDestination(target.transform.position);

        TryAttack();
    }
}
