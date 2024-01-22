using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Start()
    {
        _startScreen.Open();
        _endScreen.Close();

        _player.StopWorking();
        _enemySpawner.StopWorking();
    }

    public void OnEnable()
    {
        _startScreen.StartButtonClicked += RestartGame;
        _endScreen.RestartButtonClicked += RestartGame;
        _player.PlayerDied += StopGame;
    }

    private void OnDestroy()
    {
        _startScreen.StartButtonClicked -= RestartGame;
        _endScreen.RestartButtonClicked -= RestartGame;
        _player.PlayerDied -= StopGame;
    }

    public void StopGame()
    {
        _endScreen.Open();
        _player.StopWorking();
        _enemySpawner.StopWorking();
    }

    public void RestartGame()
    {
        _startScreen.Close();
        _endScreen.Close();

        _player.StartWorking();
        _enemySpawner.StartWorking();
    }
}
