using System;
using UnityEngine;

[RequireComponent (typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerCollisionHandler))]

public class Player : MonoBehaviour, IDamagable
{
    public event Action PlayerDied;

    private Mover _mover;
    private Attacker _attacker;
    private PlayerCollisionHandler _playerCollisionHandler;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _attacker = GetComponent<Attacker>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        _playerCollisionHandler.PlayerTouchedEnything += TakeCriticalHit;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.PlayerTouchedEnything -= TakeCriticalHit;        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _mover.FlyUp();

        if (Input.GetKeyDown(KeyCode.Space))
            _attacker.Shoot();
    }

    public void TakeCriticalHit()
    {
        _mover.Stop();
        gameObject.SetActive(false);

        PlayerDied?.Invoke();
    }

    public void GetReady()
    {
        _mover.ResetPosition();
        gameObject.SetActive(true);

        _mover.StartMovingForward();
    }
}