using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FollowPath : MonoBehaviour
{
    public MovementPath movementPath;
    public bool isFollowing = true;
    public float speed = 1;
    [Range(1f, 5f)] public float smooth;
    
    private Transform nextPointToMove;
    private bool lookedToPoint;

    void Start()
    {
        nextPointToMove = movementPath.GetNextPoint();
        if (nextPointToMove == null)
        {
            this.enabled = false;
            return;
        }
    }

    void FixedUpdate()
    {
        if (!isFollowing) return;
        transform.position = Vector2.MoveTowards(
            transform.position,
            nextPointToMove.position, 
            speed * Time.deltaTime
            );

        var distance = (transform.position - nextPointToMove.position).sqrMagnitude;
        if (distance < smooth)
        {
            nextPointToMove = movementPath.GetNextPoint();
            lookedToPoint = false;
        }
        else if (!lookedToPoint)
        {
            Vector3 targetDirection = nextPointToMove.transform.position - transform.position;
            float angle = Vector3.Angle(transform.up, targetDirection);
            if (angle < 5)
            {
                lookedToPoint = true;
            }
            transform.Rotate(0, 0, angle);
        }
    }
}