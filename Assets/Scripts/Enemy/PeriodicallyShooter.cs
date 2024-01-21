using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))]

public class PeriodicallyShooter : MonoBehaviour
{
    [SerializeField] private float _shootingDelay = 1f;

    private Attacker _attacker;
    private Coroutine _shooting;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
    }

    private void Start()
    {
        _shooting = StartCoroutine(ShootWithDelay());
    }

    private void OnEnable()
    {
        _shooting = StartCoroutine(ShootWithDelay());
    }

    private void OnDisable()
    {
        if (_shooting != null)
            StopCoroutine(ShootWithDelay());
    }

    private IEnumerator ShootWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(_shootingDelay);

        while (gameObject.activeSelf)
        {
            _attacker.Shoot();

            yield return delay;
        }
    }
}
