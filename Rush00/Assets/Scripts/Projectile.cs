using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitEffect;
    public float range = float.MaxValue;
    private void Update() {
        if (range < 0)
            Destroy(gameObject);
        range -= 10f * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
        if (collision.gameObject.layer == gameObject.layer)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
                collision.gameObject.SetActive(false);
            else
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.isDead = true;
            }
        }
    }
}