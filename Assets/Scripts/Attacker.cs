using System.Collections;
using UnityEditor;
using UnityEngine;

[RequireComponent (typeof(BulletsPool))]

public class Attacker : MonoBehaviour, IStopable
{
    [SerializeField] private ShootingFlash _shootingFlash;
    [SerializeField] private AudioSource _shootingSound;

    private BulletsPool _bulletPool;

    private void Start()
    {
        _bulletPool = GetComponent<BulletsPool>();
    }

    public void Shoot()
    {
        if (_bulletPool.TryGetBullet(out Bullet bullet))
        {
            if (_shootingSound != null)
                _shootingSound.Play();

            if (_shootingFlash != null)
                _shootingFlash.gameObject.SetActive(true);

            bullet.StartFlight(transform.right);
        }
    }

    public void StopWorking()
    {
        ResetCondition();
    }

    public void ResetCondition()
    {
        _bulletPool.DisableAllBullets();
    }

    public void StartWorking()
    {
        return;
    }
}