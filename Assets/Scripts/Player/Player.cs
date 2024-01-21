using UnityEngine;

[RequireComponent (typeof(Mover))]
[RequireComponent(typeof(Attacker))]

public class Player : MonoBehaviour, IDamagable
{
    private Mover _mover;
    private Attacker _attacker;

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _attacker = GetComponent<Attacker>();
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
        return;
    }
}