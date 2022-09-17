using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    public float speed = 4f;
    public float mouseSpeed = 14f;
    
    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private float NormalizeSpeed(float fromSpeed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
            fromSpeed *= 2;
        return fromSpeed * Time.fixedDeltaTime * speed;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var mouseV = Input.GetAxisRaw("Mouse X");
            var mouseH = -Input.GetAxisRaw("Mouse Y");
            transform.Rotate(mouseH * mouseSpeed, mouseV * mouseSpeed, 0);

            var rotationEffect = new Vector3(mouseH * mouseSpeed, mouseV * mouseSpeed, 0);
            var targetRotation = transform.eulerAngles + rotationEffect;
            targetRotation.z = 0;
            transform.eulerAngles = targetRotation;
        }
    }
    

    private void FixedUpdate()
    {
        // if (!_canMove) return;
        _rb.velocity = new Vector3();
        
        var speedX = Input.GetAxisRaw("Horizontal");
        var speedZ = Input.GetAxisRaw("Vertical");
        var speedY = Input.GetAxisRaw("Topdown");

        transform.Translate(NormalizeSpeed(speedX), NormalizeSpeed(speedY), NormalizeSpeed(speedZ));
    }
}
