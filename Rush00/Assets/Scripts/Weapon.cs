using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Melee,
        Single,
        Auto
    }
    
    public enum Attributes
    {
	    InfiniteAmmo = -1
    }
    

    public Sprite icon;
    public Transform firePoint;
    // public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public WeaponType type = WeaponType.Single;
    public int ammo = 20;
	public GameObject user = null;
    private AudioSource _shotSound;
	// public Rigidbody2D selfRigidBody;
	public Vector3 offset;

	public GameObject throable;

	public Transform player;

	private void Start()
	{
		_shotSound = GetComponent<AudioSource>();
	}
	
	public void UnsetUser()
	{
		// user = null;
	}
	
	private void Update() {
		if (player)
		{
			transform.position = player.position;
			transform.rotation = player.rotation;
		}

	}

    public void Shoot(int enemyLayer, Transform firePoint)
    {
	    if (ammo == 0)
		    return;
	    if (ammo != (int)Attributes.InfiniteAmmo)
		    --ammo;
	    _shotSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * bulletPrefab.transform.rotation);
        bullet.layer = enemyLayer;
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}