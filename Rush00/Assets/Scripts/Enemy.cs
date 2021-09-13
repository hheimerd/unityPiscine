using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Weapon weapon;
    public int enemyLayer;
    public GameSounds gameSounds;
    public bool isDead = false;
    
    public GameObject legs;
    private Animator _legsAnimator;
    private bool canShoot = true;
    private float reloadTime = 3f;
    public Transform weaponPosition;

    // Use this for initialization
    private void Start()
    {
        _legsAnimator = legs.GetComponent<Animator>();
        InvokeRepeating("Reload", 0f, reloadTime);
    }

    void Reload()
    {
        canShoot = true;
    }
    

    public void Shoot()
    {
        if (canShoot)
        {
            weapon.Shoot(enemyLayer, weaponPosition);//TODO add target
            canShoot = false;
        }
    }

    private void OnDestroy()
    {
        gameSounds.PlayDeathSound();
    }
}