using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(AudioSource))]

public class Explosion : MonoBehaviour
{
    private AudioSource _sound;

    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void Activate(Vector3 position)
    {
        transform.position = position;
        _sound.Play();
    }
}
