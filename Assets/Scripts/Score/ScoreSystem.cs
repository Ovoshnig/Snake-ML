using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    private int _currentScore;
    public event Action<int> OnScoreChanged;

    public void AddPoints(int points)
    {
        _currentScore += points;
        OnScoreChanged?.Invoke(_currentScore);
    }

    public void ResetScore()
    {
        _currentScore = 0;
        OnScoreChanged?.Invoke(_currentScore);
    }

    public int GetCurrentScore() => _currentScore;
}
