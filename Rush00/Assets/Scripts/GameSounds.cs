using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameSounds : MonoBehaviour
{
    public List<AudioClip> deathSounds;
    public AudioClip noAmmo;
    public AudioClip takeWeapon;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {
        int randomNumber = Random.Range(0, deathSounds.Count - 1);
        _audioSource.clip = deathSounds[randomNumber];
        _audioSource.Play();
    }

    public void PlayNoAmmo()
    {
        _audioSource.clip = noAmmo;
        _audioSource.Play();
    }

    public void PlayTakeWeapon()
    {
        _audioSource.clip = takeWeapon;
        _audioSource.Play();
    }
}