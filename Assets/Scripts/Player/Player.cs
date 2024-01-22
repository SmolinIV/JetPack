using System;
using UnityEngine;

[RequireComponent (typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerCollisionHandler))]

public class Player : MonoBehaviour, IDamagable, IStopable
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
        PlayerDied?.Invoke();
    }

    public void StopWorking()
    {
        gameObject.SetActive(false);
    }

    public void ResetCondition()
    {
        _mover.ResetPosition();   
    }

    public void StartWorking()
    {
        ResetCondition();
        gameObject.SetActive(true);
        _mover.MoveForward();
    }
}