using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyPool))]

public class EnemySpawner : MonoBehaviour, IStopable
{
    [SerializeField] private Transform _upperLimitPosition;
    [SerializeField] private Transform _lowerLimitPosition;
    [SerializeField] private float _spawnFrequency = 2;

    private EnemyPool _enemyPool;
    private Coroutine _spawningEnemies;
    private Vector3 _startPosition;

    private float _upperLimitY;
    private float _lowerLimitY;

    private void OnDisable()
    {
        if (_spawningEnemies != null)
            StopCoroutine(SpawnEnemy());
    }

    private void Awake()
    {
        _enemyPool = GetComponent<EnemyPool>();

        _upperLimitY = _upperLimitPosition.position.y;
        _lowerLimitY = _lowerLimitPosition.position.y;
        _upperLimitPosition.gameObject.SetActive(false);
        _lowerLimitPosition.gameObject.SetActive(false);
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private Vector3 GetNewRandomPosition()
    {
        float newPositionY = Random.Range(_lowerLimitY, _upperLimitY);

        return new Vector3(transform.position.x, newPositionY);
    }

    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnFrequency);

        while (gameObject.activeSelf)
        {
            yield return delay;

            transform.position = GetNewRandomPosition();
            _enemyPool.TryGetEnemy(out Enemy enemy);

        }

        yield break;
    }

    public void StopWorking()
    {
        if (_spawningEnemies != null)
            StopCoroutine(_spawningEnemies);

        ResetCondition();
    }

    public void ResetCondition()
    {
        _enemyPool.DisableAllEnemies();
    }

    public void StartWorking()
    {
        transform.position = _startPosition;
        _spawningEnemies = StartCoroutine(SpawnEnemy());
    }
}
