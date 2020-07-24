using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource hitSoundEffect;

    private void Start()
    {
        hitSoundEffect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitSoundEffect.Play();
    }
}
