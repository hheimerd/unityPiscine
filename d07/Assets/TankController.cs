using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 7;
    public float rotationSpeed = 7;
    public float cannonRotationSpeed = 14;
    public int rocketsLeft = 10;
    public float maxNitroTime = 4;
    public bool nitroIsOn = false;
    public float nitroSpeed = 10;
    [SerializeField]private float machineGunReloadTime = 0.1f;
    [SerializeField]private float rocketReloadTime = 10;
    [SerializeField]private Transform cannon;
    [SerializeField]private Transform ammoSpawn;
    [SerializeField]private Ammo bullets;
    [SerializeField]private Ammo rocket;
    [SerializeField]private ParticleSystem shootSmoke;
    private bool _canShootRocket = true;
    private bool _canShootMachimeGun = true;
    private float _nitroRemins;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(ReloadRocket), 0, rocketReloadTime);
        InvokeRepeating(nameof(ReloadMachineGun), 0, machineGunReloadTime);
        InvokeRepeating(nameof(ReloadNitro), 0, 4);
        _nitroRemins = maxNitroTime;
    }

    public void ReloadMachineGun()
    {
        _canShootMachimeGun = true;
    }
    
    public void ReloadRocket()
    {
        _canShootRocket = true;
    }
    
    public void Rotate(float angle)
    {
        var rotateAngle = Quaternion.Euler(0, angle * rotationSpeed, 0);
        var newRotation = _rb.rotation * rotateAngle;
        _rb.MoveRotation(newRotation);
    }

    public void Move(float movementSpeed)
    {
        var move = transform.forward * movementSpeed;
        if (nitroIsOn && _nitroRemins > 0)
            move *= nitroSpeed;
        else
            move *= speed;

        var newPosition = _rb.position + move;
        _rb.MovePosition(newPosition);
    }

    public void Shoot(Ammo ammo, float speed)
    {
        shootSmoke.Emit(1);
        var bullet = Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);
        bullet.rigidbody.AddForce(bullet.transform.forward * speed);
    }

    public void ShootMachineGun()
    {
        if (!_canShootMachimeGun) return;

        Shoot(bullets, 2000);
        _canShootMachimeGun = false;
    }

    private void ReloadNitro()
    {
        _nitroRemins = maxNitroTime;
    }
    
    public void ShootRocket()
    {
        if (!_canShootRocket || rocketsLeft < 1) return;

        rocketsLeft -= 1;
        Shoot(rocket, 800);
        _canShootRocket = false;
    }

    public void RotateCannon(float rotation)
    {
        cannon.Rotate(0, rotation * cannonRotationSpeed, 0);
    }

    private void Update()
    {
        if (nitroIsOn && _nitroRemins > 0)
            _nitroRemins -= Time.deltaTime * 4;
    }
}
