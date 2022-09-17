using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public AttackController attackController;

    
    private static readonly int Speed = Animator.StringToHash("Speed");



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);

                var attackable = hit.collider.GetComponent<Attacable>();
                if (attackable)
                {
                    attackController.SetTarget(attackable);
                }
            }
        }

        transform.position += agent.velocity * Time.deltaTime;

        animator.SetFloat(Speed, agent.velocity.sqrMagnitude);

    }
}
