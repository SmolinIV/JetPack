using System;
using UnityEngine;

[RequireComponent (typeof(Mover))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]

public class Player : MonoBehaviour, IDamagable, IStopable
{
    [SerializeField] private Explosion _explosionPrefab;

    public event Action PlayerDied;

    private Mover _mover;
    private Attacker _attacker;
    private PlayerCollisionHandler _playerCollisionHandler;
    private ScoreCounter _scoreCounter;

    private bool _isFlyingBlocked;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _attacker = GetComponent<Attacker>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    public void OnEnable()
    {
        _playerCollisionHandler.RecievedFatalTouch += TakeFatalHit;
        _playerCollisionHandler.TouchedUpperBlock += BlockFlying;
        _playerCollisionHandler.ComeDown += UnblockFlying;
        Enemy.Destroyed += _scoreCounter.Add;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.RecievedFatalTouch -= TakeFatalHit;
        _playerCollisionHandler.TouchedUpperBlock -= BlockFlying;
        _playerCollisionHandler.ComeDown -= UnblockFlying;
        Enemy.Destroyed -= _scoreCounter.Add;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isFlyingBlocked)
            _mover.FlyUp();

        if (Input.GetKeyDown(KeyCode.Space))
            _attacker.Shoot();
    }

    public void TakeFatalHit()
    {
        Explosion explosionEffect = Instantiate(_explosionPrefab);
        explosionEffect.Activate(transform.position);

        PlayerDied?.Invoke();
    }

    public void StopWorking()
    {
        gameObject.SetActive(false);
    }

    public void ResetCondition()
    {
        _mover.ResetPosition();   
        _scoreCounter.ResetScore();
    }

    public void StartWorking()
    {
        ResetCondition();
        gameObject.SetActive(true);
        _mover.MoveForward();
    }

    private void BlockFlying()
    {
        _isFlyingBlocked = true;
        _mover.MoveForward();
    }

    private void UnblockFlying()
    {
        _isFlyingBlocked = false;
    }
}