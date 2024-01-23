using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private int _bulletCount = 10;

    private List<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new List<Bullet>();

        for (int i = 0; i < _bulletCount; i++)
        {
            _bullets.Add(Instantiate(_bulletPrefab));
            _bullets[i].gameObject.SetActive(false);
        }
    }

    public bool TryGetBullet(out Bullet spawnedBullet)
    {
        spawnedBullet = null;

        foreach (Bullet bullet in _bullets)
        {
            if (bullet.gameObject.activeSelf == false)
            {
                spawnedBullet = bullet;
                spawnedBullet.transform.position = _bulletSpawnPoint.transform.position;
                spawnedBullet.InitializeShooter(gameObject);
                spawnedBullet.gameObject.SetActive(true);

                return true;
            }
        }

        return false;
    }

    public void DisableAllBullets()
    {
        foreach (Bullet bullet in _bullets)
            bullet.gameObject.SetActive(false);
    }
}
