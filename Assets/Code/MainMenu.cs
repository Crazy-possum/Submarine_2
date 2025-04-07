using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _tutorialButton;

    private void Start()
    {
        ShowBestScore();
        PlayGame();
        TutorialButton();
    }

    private void ShowBestScore()
    {
        _bestScoreText.text = $"The best score: {PlayerPrefs.GetInt("BestScore")}";
    }

    private void TutorialButton()
    {
        _tutorialButton.onClick.AddListener(OpenTutorial);
    }
   
    private void PlayGame()
    {
        _playButton.onClick.AddListener(LoadPGameScene);
    }

    private void LoadPGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenTutorial()
    {
        _tutorial.SetActive(true);
    }
}
