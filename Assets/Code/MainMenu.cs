using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private Button _playButton;

    private void Start()
    {
        ShowBestScore();
        PlayGame();
    }

    private void ShowBestScore()
    {
        _bestScoreText.text = $"The best score: {PlayerPrefs.GetInt("BestScore")}";
    }

    private void PlayGame()
    {
        _playButton.onClick.AddListener(LoadPGameScene);
    }

    private void LoadPGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
