using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Score _currentScore;

    private void Start()
    {
        _startScreen.Open();
        _currentScore.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.BirdDied += OnBirdDied;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.BirdDied -= OnBirdDied;
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        _currentScore.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    private void OnRestartButtonClicked()
    {
        _gameOverScreen.Close();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnBirdDied()
    {
        Time.timeScale = 0;

        _currentScore.gameObject.SetActive(false);
        _gameOverScreen.Open();
    }
}
