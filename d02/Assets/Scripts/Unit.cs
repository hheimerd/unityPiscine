using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed;
    public Rigidbody2D _rb;
    public Animator animator;
    public AudioSource walkSound;

    private Vector2 _movement;
    private Vector2 _targetPosition;

    private bool _isMoving = false;
    // Update is called once per frame

    void Update()
    {
        // _movement.x = Input.GetAxisRaw("Horizontal");
        // _movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Speed", _movement.sqrMagnitude);

        var scale = transform.localScale;
        scale.x = Math.Abs(scale.x);
        if (_movement.x < 0) scale.x *= -1;
        transform.localScale = scale;
    }

    public void SetTargetPosition()
    {
        _rb.isKinematic = false;
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _movement = _targetPosition - _rb.position;
        _isMoving = true;
        if (!walkSound.isPlaying)
            walkSound.Play();
    }

    private void Move()
    {
        float calcSpeed = speed;
        if (_movement.x != 0 && _movement.y != 0)
            calcSpeed /= 2;

        var newPosition = Vector2.MoveTowards(
            transform.position, _targetPosition,
            calcSpeed * Time.fixedDeltaTime
        );
        _rb.MovePosition(newPosition);

        if (((Vector2) transform.position).Equals(_targetPosition))
        {
            OnStopMoving();
        }
    }

    void OnStopMoving()
    {
        _isMoving = false;
        _rb.isKinematic = true;
        walkSound.Stop();
        _movement = new Vector2();
    }
    // void OnCollisionStay2D(Collision2D col)
    // {
    //     if (_isMoving)
    //     {
    //         if (col.gameObject.GetComponent<Unit>()._isMoving == false)
    //         {
    //             OnStopMoving();
    //         }
    //     }
    // }
    private void FixedUpdate()
    {
        if (_isMoving) Move();
    }
}