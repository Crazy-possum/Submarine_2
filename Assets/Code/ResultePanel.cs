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
    [SerializeField] private GameObject _resulePanel;

    [SerializeField] private TMP_Text _newRecordText;
    [SerializeField] private TMP_Text _yourScoreText;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private int _bestScore;

    private void Start()
    {
        RestartGame();
        ToMainMenu();
    }

    public void OpenResultPanel()
    {
        _resulePanel.SetActive(true);
        _bestScore = 0;
        SetData();
    }

    public void CloseResultePanel()
    {
        _resulePanel.SetActive(false);
    }

    private void SetData()
    {
        _yourScoreText.text = $"Your score:{_playerBehavior.Score}";
        _bestScoreText.text = $"The best score: {_bestScore}";

        if (_bestScore < _playerBehavior.Score)
        {
            _newRecordText.enabled = true;
            _bestScore = _playerBehavior.Score;
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
