using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        _scoreSystem.OnScoreChanged += UpdateScoreDisplay;
        _gameState.OnGameOver += ShowGameOver;
    }

    private void OnDisable()
    {
        _scoreSystem.OnScoreChanged -= UpdateScoreDisplay;
        _gameState.OnGameOver -= ShowGameOver;
    }

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        UpdateScoreDisplay(0);
    }

    private void UpdateScoreDisplay(int score)
    {
        _scoreText.text = $"Score: {score}";
    }

    private void ShowGameOver(int finalScore)
    {
        _gameOverPanel.SetActive(true);
        _finalScoreText.text = $"Final Score: {finalScore}";
    }
}