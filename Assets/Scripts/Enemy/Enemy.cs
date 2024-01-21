using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private Explosion _explosionPrefab;
    [SerializeField] private float _speed = 3f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    public void TakeCriticalHit()
    {
        Destroy();
    }

    private void Destroy()
    {
        Explosion explosionEffect = Instantiate(_explosionPrefab);
        explosionEffect.transform.position = transform.position;
        explosionEffect.Activate();
        gameObject.SetActive(false);
    }

}
