using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Camera cam;
	public float moveSpeed = 10f;

	public Weapon weapon;
	// public GameObject weaponPref;
	public int enemyLayer;
	
	public Rigidbody2D rb;
	private Vector2 _movement;
	private Vector2 _mousePos;

	public GameObject legs;
	private Animator _legsAnimator;

	public GameObject GUI;
	public GameObject weaponPosition;
	public GameObject ThroablePosition;
	public GameObject FirePoint;

	public GameObject gameOverMenu;
	public GameObject victoryOverMenu;

	public GameSounds gameSounds;
	
	private void Start()
	{
		_legsAnimator = legs.GetComponent<Animator>();
	}

	// Update is called once per frame
	private void Update()
	{
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");
		
		_mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		
		bool moving = _movement.x != 0 || _movement.y != 0;
		_legsAnimator.SetBool("Is moving", moving);
		
		if (Input.GetButtonDown("Fire1") && weapon)
		{
			if (weapon.ammo == 0)
				gameSounds.PlayNoAmmo();
			else
			{
				weapon.Shoot(enemyLayer, FirePoint.transform);
				OnMakeSound();
			}
		}
		if (Input.GetButtonDown("Fire2") && weapon)
		{
			var obj = Instantiate(weapon.throable, ThroablePosition.transform.position, transform.rotation);
			obj.GetComponent<Throable>().bullets = weapon.ammo;
			weapon.player = null;
			obj.GetComponent<Rigidbody2D>().AddForce(FirePoint.transform.up * 50f, ForceMode2D.Impulse);
			weapon.gameObject.GetComponent<Weapon>().player = null;
			Destroy(weapon.gameObject);
			weapon = null;
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + _movement * (moveSpeed * Time.deltaTime));
		Vector2 lookDir = _mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
		rb.rotation = angle;
	}
	
	private void OnDisable()
	{
		gameSounds.PlayDeathSound();
		GUI.SetActive(false);
		gameOverMenu.SetActive(true);
		Menu.Pause();
	}


	private List<OnMakeSoundCallback> soundListenersCallbacks = new List<OnMakeSoundCallback>();
	public delegate void OnMakeSoundCallback();
	public void AddSoundListener(OnMakeSoundCallback cb)
	{
		soundListenersCallbacks.Add(cb);
	}

	private void OnMakeSound()
	{
		foreach (var cb in soundListenersCallbacks)
		{
			cb();
		}
	}
	
	public void Win()
	{
		GUI.SetActive(false);
		victoryOverMenu.SetActive(true);
		Menu.Pause();
	}
	
}