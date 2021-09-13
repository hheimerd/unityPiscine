using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throable : MonoBehaviour {

	public Weapon usable;
	public GameObject prefab;
	public int bullets;

	public float force;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.sqrMagnitude != 0)
		{
			rb.AddForce(rb.velocity * (-force * Time.deltaTime), ForceMode2D.Impulse);
			rb.angularVelocity = 0;
		}
	}

	private void OnTriggerStay2D(Collider2D collision) {
		if (Input.GetKeyDown("e"))
		{
			if (collision.gameObject.GetComponent<Human>())
			{
				Human human = collision.gameObject.GetComponent<Human>();
				if (human.GetComponent<Enemy>() == null && collision.gameObject.GetComponent<Player>().weapon == null)
				{
					var obj = Instantiate(prefab, human.transform.position, human.transform.rotation);
					obj.GetComponent<Weapon>().player = collision.gameObject.GetComponent<Player>().weaponPosition.transform;
					collision.gameObject.GetComponent<Player>().weapon = obj.GetComponent<Weapon>();
					collision.gameObject.GetComponent<Player>().weapon.ammo = bullets;
					Destroy(gameObject);
				}
			}
		}
	}
}
