using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _scoreCounter.Changed += ChangeScore;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= ChangeScore;
    }

    private void ChangeScore(int newScore)
    {
        _text.text = newScore.ToString();
    }
}
