using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public void Die()
    {
        if (GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
            GameObject.FindWithTag("GameOverMenu").SetActive(true);
            Menu.Pause();
        }
        else
        {
        }
    }
}
