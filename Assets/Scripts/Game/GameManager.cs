using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityAction<bool> ShowEndGamePanelEvent;

    private Player _player;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        Time.timeScale = 1f;
        _player = FindObjectOfType<Player>();
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void OnEnable()
    {
        _player.EndGameEvent += EndGame;
    }
    private void OnDisable()
    {
        _player.EndGameEvent -= EndGame;
    }
    private void EndGame()
    {
        UpdateHighScore();
        Time.timeScale = 0f;
        ShowEndGamePanelEvent.Invoke(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void RestartLevel()
    {
        _sceneLoader.LoadScene(Helper.GAME_SCENE);
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        _sceneLoader.LoadScene(Helper.MAIN_MENU_SCENE);
    }
    private void UpdateHighScore()
    {
        if(PlayerPrefs.GetInt(Helper.PLAYER_SCORE)<_player.GetScore())
        {
            PlayerPrefs.SetInt(Helper.PLAYER_SCORE, _player.GetScore());
        }
    }
}
