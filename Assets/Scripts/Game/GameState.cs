using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    [SerializeField] private Snake _snake;
    [SerializeField] private ScoreSystem _scoreSystem;

    private bool _isGameOver;
    public event Action<int> OnGameOver;

    private void Update()
    {
        if (!_isGameOver && _snake.CheckSelfCollision())
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _isGameOver = true;
        OnGameOver?.Invoke(_scoreSystem.GetCurrentScore());
    }
}