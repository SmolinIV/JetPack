using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<int> Changed;

    private int _score;

    public void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
        Changed?.Invoke(_score);
    }
}
