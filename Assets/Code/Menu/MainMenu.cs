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
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _clearProgress;

    private void Start()
    {
        ShowBestScore();
        ClearProgress();
    }

    public void ShowBestScore()
    {
        if (PlayerPrefs.GetInt("isRussian") == 1)
        {
            _bestScoreText.text = $"Лучший счет: {PlayerPrefs.GetInt("BestScore")}";
            _bestMetreText.text = $"Максимальное погружение: {PlayerPrefs.GetInt("BestFootage")} м";
        }
        else
        {
            _bestScoreText.text = $"The best score: {PlayerPrefs.GetInt("BestScore")}";
            _bestMetreText.text = $"The best footage: {PlayerPrefs.GetInt("BestFootage")} m";
        }
    }

    private void ClearProgress()
    {
        _clearProgress.onClick.AddListener(RemoveALL);
    }

    private void RemoveALL()
    {
        PlayerPrefs.DeleteKey("TutorialStage");
        PlayerPrefs.DeleteKey("TutorialYellowStage");
        PlayerPrefs.DeleteKey("TutorialRedStage");
        SceneManager.LoadScene(0);
    }
}
