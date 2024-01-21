using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount = 10;

    private List<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new List<Enemy>();

        for (int i = 0; i < _enemyCount; i++)
        {
            _enemies.Add(Instantiate(_enemyPrefab));
            _enemies[i].gameObject.SetActive(false);
        }
    }

    public bool TryGetEnemy(out Enemy spawnedEnemy)
    {
        spawnedEnemy = null;

        foreach (Enemy enemy in _enemies)
        {
            if (enemy.gameObject.activeSelf == false)
            {
                spawnedEnemy = enemy;
                spawnedEnemy.transform.position = transform.position;
                spawnedEnemy.gameObject.SetActive(true);

                return true;
            }
        }

        return false;
    }
}
