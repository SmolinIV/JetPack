using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable target))
        {
            target.TakeCriticalHit();
            gameObject.SetActive(false);
        }
    }

    public void StartFlight(Vector3 direction)
    {
        _rigidbody2D.velocity = direction * _speed;
    }

    public void InitializeShooter(GameObject shooter)
    {
        Collider2D[] throwerColloders = shooter.GetComponents<Collider2D>();

        foreach (Collider2D collider in throwerColloders)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, true);
    }
}
