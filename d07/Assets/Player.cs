using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public TankController tank;

    // Update is called once per frame
    void Update()
    {
        var forwardSpeed = Input.GetAxis("Vertical");
        var sideSpeed = Input.GetAxis("Horizontal");
        var canonRotation = Input.GetAxis("Mouse X");

        if (forwardSpeed < 0)
            sideSpeed *= -1;
        
        tank.Move(forwardSpeed * Time.deltaTime);
        tank.nitroIsOn = Input.GetKey(KeyCode.LeftShift);
        tank.Rotate(sideSpeed * Time.deltaTime);
        tank.RotateCannon(canonRotation * Time.deltaTime);

        if (Input.GetMouseButton(0))
            tank.ShootMachineGun();
        else if (Input.GetMouseButton(1))
            tank.ShootRocket();
    }
}
