using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Viev : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pauseGameButton;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _resumeButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject[] _hpImages;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gamePanelText;


    private GameManager _gameManager;
    private Player _player;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        _restartButton.GetComponent<Button>().onClick.AddListener(_gameManager.RestartLevel);
        _resumeButton.GetComponent<Button>().onClick.AddListener(ResumeGame);
        _exitButton.GetComponent<Button>().onClick.AddListener(_gameManager.ExitGame);
        _pauseGameButton.GetComponent<Button>().onClick.AddListener(PauseGame);
    }

    private void OnEnable()
    {
        _player.ScoreChangerEvent += ShowScoreText;
        _player.HpChanger += ShowHearts;
        _gameManager.ShowEndGamePanelEvent += ShowGamePanel;
        
    }
    private void OnDisable()
    {
        _player.ScoreChangerEvent -= ShowScoreText;
        _player.HpChanger -= ShowHearts;
        _gameManager.ShowEndGamePanelEvent -= ShowGamePanel;
    }
    private void ShowScoreText(int value)
    {
        _scoreText.text = "SCORE: " + value.ToString();
    }
    private void ShowHearts(int value)
    {
        _hpImages[value].SetActive(false);
    }
    private void ShowGamePanel(bool value)
    {
        if (value)
        {
            _gamePanelText.text = "PAUSE";
        }
        else if(!value)
        {
            _gamePanelText.text = "GAME OVER";
            _resumeButton.SetActive(false);
            _pauseGameButton.SetActive(false);
        }
        _gamePanel.SetActive(true);
    }
    private void PauseGame()
    {
        _gameManager.PauseGame();
        ShowGamePanel(true);
        _pauseGameButton.SetActive(false);

    }
    private void ResumeGame()
    {
        _gameManager.ResumeGame();
        _gamePanel.SetActive(false);
        _pauseGameButton.SetActive(true);
    }

}
