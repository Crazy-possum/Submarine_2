using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _bestMetreText;
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _clearProgress;

    private void Start()
    {
        ShowBestScore();
        PlayGame();
        ClearProgress();
    }

    private void ShowBestScore()
    {
        _bestScoreText.text = $"The best score: {PlayerPrefs.GetInt("BestScore")}";
        _bestMetreText.text = $"The best footage: {PlayerPrefs.GetInt("BestFootage")} m";
    }
   
    private void PlayGame()
    {
        _tutorialButton.onClick.AddListener(LoadPGameScene);
    }

    private void LoadPGameScene()
    {
        SceneManager.LoadScene(1);
    }

    private void ClearProgress()
    {
        _clearProgress.onClick.AddListener(RemoveALL);
    }

    private void RemoveALL()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
