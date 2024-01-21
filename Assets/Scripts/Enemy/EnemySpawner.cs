using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnFrequency = 2;
    [SerializeField] private Transform _upperLimitY;
    [SerializeField] private Transform _lowerLimitY;

    private EnemyPool _enemyPool;
    private Coroutine _spawningEnemies;

    private Vector3 _upperPosition;
    private Vector3 _lowerPosition;

    private void OnDisable()
    {
        if (_spawningEnemies != null)
            StopCoroutine(SpawnEnemy());
    }

    private void Awake()
    {
        _enemyPool = GetComponent<EnemyPool>();

        _upperPosition = _upperLimitY.transform.position;
        _lowerPosition = _lowerLimitY.transform.position;
        _upperLimitY.gameObject.SetActive(false);
        _lowerLimitY.gameObject.SetActive(false);

        _spawningEnemies = StartCoroutine(SpawnEnemy());
    }

    private Vector3 GetNewRandomPosition()
    {
        System.Random random = new System.Random();
        float newPositionY = (float)(random.NextDouble() * (_upperPosition.y - _lowerPosition.y) + _lowerPosition.y);

        return new Vector3(transform.position.x, newPositionY);
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnFrequency);

        while (gameObject.activeSelf)
        {
            transform.position = GetNewRandomPosition();
            _enemyPool.TryGetEnemy(out Enemy enemy);

            yield return delay;
        }
    }
}
