using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultePanel : MonoBehaviour
{
    [SerializeField] private PlayerBehavior _playerBehavior;
    [SerializeField] private MetreController _metreController;
    [SerializeField] private GameObject _resulePanel;

    [SerializeField] private TMP_Text _newRecordText;
    [SerializeField] private TMP_Text _yourScoreText;
    [SerializeField] private TMP_Text _yourMetreScore;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _bestMetreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private int _bestScore;
    private int _bestMetre;

    private void Start()
    {
        RestartGame();
        ToMainMenu();
    }

    public void OpenResultPanel()
    {
        _resulePanel.SetActive(true);
        SetData();
    }

    public void CloseResultePanel()
    {
        _resulePanel.SetActive(false);
    }

    private void SetData()
    {
        if (PlayerPrefs.GetInt("isRussian") == 1)
        {
            _yourScoreText.text = $"Ваш счет: {_playerBehavior.Score}";
            _yourMetreScore.text = $"Вы достигли: {_metreController.MetreRecord} м";
            _bestScoreText.text = $"Лучший ссчет: {PlayerPrefs.GetInt("BestScore")}";
            _bestMetreText.text = $"Максимальная глубина: {PlayerPrefs.GetInt("BestFootage")} м";
        }
        else
        {
            _yourScoreText.text = $"Your score: {_playerBehavior.Score}";
            _yourMetreScore.text = $"You reached: {_metreController.MetreRecord} m";
            _bestScoreText.text = $"The best score: {PlayerPrefs.GetInt("BestScore")}";
            _bestMetreText.text = $"The best footage: {PlayerPrefs.GetInt("BestFootage")} m";
        }

        if (PlayerPrefs.GetInt("BestScore") < _playerBehavior.Score)
        {
            _newRecordText.gameObject.SetActive(true);
            _bestScore = _playerBehavior.Score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
        if (PlayerPrefs.GetInt("BestFootage") < _metreController.MetreRecord)
        {
            _newRecordText.gameObject.SetActive(true);
            _bestMetre = _metreController.MetreRecord;
            PlayerPrefs.SetInt("BestFootage", _bestMetre);
        }
    }

    private void RestartGame()
    {
        _restartButton.onClick.AddListener(RestartGameScene);
    }

    private void ToMainMenu()
    {
        _mainMenuButton.onClick.AddListener(LoadMainMenuScene);
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }    
    private void RestartGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
