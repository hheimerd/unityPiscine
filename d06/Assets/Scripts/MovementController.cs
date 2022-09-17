using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MovementController : MonoBehaviour
{

    public float speed = 3;
    public float runSpeed = 5;
    public float gravity = -10f;
    public float mouseSpeed = 3;
    private CharacterController _character;
    public Camera characterCamera;
    public Animator animator;
    public float maxCameraAngle = 60;
   
    public AudioSource stepSound;
    
    void Start()
    {
        stepSound = GetComponent<AudioSource>();
        _character = GetComponent<CharacterController>();
    }

    float CorrectSpeed(float rawSpeed)
    {
        var shift = Input.GetKey(KeyCode.LeftShift);
        var newSpeed = rawSpeed * Time.fixedDeltaTime;
        if (shift)
            return newSpeed * runSpeed;
        return newSpeed * speed;
    }

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = -Input.GetAxis("Mouse Y");
        var mouseEffect = new Vector3(mouseY, mouseX, 0);

        transform.eulerAngles += Vector3.up * (mouseX * mouseSpeed);

        var cameraRotation = characterCamera.transform.eulerAngles + Vector3.right * (mouseY * mouseSpeed % 360);
        if (cameraRotation.x < maxCameraAngle / 2 || cameraRotation.x > 360 - maxCameraAngle / 2)
            characterCamera.transform.eulerAngles = cameraRotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x;
        float z;
        bool jumpPressed = false;
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
       
        Vector3 move = transform.right * x + transform.forward * z;
        var shift = Input.GetKey(KeyCode.LeftShift);
        var newSpeed = move * Time.fixedDeltaTime;
        newSpeed *= shift ? runSpeed : speed;
        
        animator.SetFloat("SpeedForward", move.sqrMagnitude);

        if (move.sqrMagnitude > 0.3 && !stepSound.isPlaying)
        {
            stepSound.pitch = (float)(new Random()).Next(5, 10) / 7;
            stepSound.Play();
        }
        
        _character.Move(newSpeed);

        var velocity = new Vector3();
        velocity.y = gravity * Time.fixedDeltaTime;
        _character.Move(velocity);
    }
}
