using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public LightDangerUI lightUI;
    public TMP_Text uiMessage;
    public bool inSmoke;
    public bool haveKey;
    public AudioSource normalMusic;
    public AudioSource panicMusic;

    private void FixedUpdate()
    {
        if (lightUI.visibilityScale > 75)
        {
            if (normalMusic.isPlaying)
            {
                normalMusic.Stop();
            }
            if (!panicMusic.isPlaying)
            {
                panicMusic.Play();
            }
        }
        else
        {
            if (!normalMusic.isPlaying)
            {
                normalMusic.Play();
            }
            if (panicMusic.isPlaying)
            {
                panicMusic.Stop();
            }
        }
        if (lightUI.visibilityScale >= 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // inSmoke = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag.Equals("Smoke"))
            inSmoke = true;
    }

    private void LateUpdate()
    {
        inSmoke = false;
    }

    public void Detected(float upStep)
    {
        if (inSmoke)
            upStep /= 3;
        lightUI.visibilityScale += upStep;
    }

    public void SetUIMessage(string message)
    {
        uiMessage.text = message;
    }
}
