using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JetSoundPlayer : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _maxVolume;

    private AudioSource _jetSound;

    private void Start()
    {
        _jetSound = GetComponent<AudioSource>();
        _jetSound.volume = _maxVolume;
    }

    public void TurnOn() => _jetSound.Play();


    public void TurnOff() => _jetSound.Stop();
}
