using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _loadingText;

    private SceneLoader _sceneLoader;

   private void Start()
    {
        
        _sceneLoader = FindObjectOfType<SceneLoader>();
        _startGameButton.GetComponent<Button>().onClick.AddListener(LoadingTextShow);
        LoadScore();
    }
    private void LoadGameLevel()
    {

        _sceneLoader.LoadScene(Helper.GAME_SCENE);
    }
    private IEnumerator LoadingTextShowCo()
    {
        _loadingText.SetActive(true);
        _startGameButton.SetActive(false);
        int x = 0;
        while ( x < 4){ 
        yield return new WaitForSeconds(0.2f);
        _loadingText.GetComponent<Text>().text += ".";
            x++;
        }
        LoadGameLevel();

    }
    private void LoadingTextShow()
    {
        StartCoroutine(LoadingTextShowCo());
    }
    private void LoadScore()
    {
        _scoreText.text += PlayerPrefs.GetInt(Helper.PLAYER_SCORE);

    }


}
