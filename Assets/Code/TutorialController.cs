using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject _firstTutPanel;
    [SerializeField] private GameObject _redSignalPanel;
    [SerializeField] private GameObject _yellowSignalPanel;
    [SerializeField] private GameObject _hpLosePanel;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _secondTutBut;
    [SerializeField] private Button _thirdTutBut;
    [SerializeField] private Button _fourthTutBut;
    [SerializeField] private Button _fifthTutBut;

    private float _musicTime;

    private void Start()
    {
        TimeButton();
        
        Time.timeScale = 0;
        _audioSource.Stop();

        if (PlayerPrefs.GetInt("TutorialStage") >= 1)
        {
            _firstTutPanel.SetActive(false);
            Time.timeScale = 1;
            _audioSource.Play();
        }
    }

    public void RedSignalTutorial()
    {
        Time.timeScale = 0;
        _musicTime = _audioSource.time;
        _audioSource.Stop();
        _redSignalPanel.SetActive(true);
        PlayerPrefs.SetInt("TutorialRedStage", 1);
    }

    public void YellowSignalTutorial()
    {
        Time.timeScale = 0;
        _musicTime = _audioSource.time;
        _audioSource.Stop();
        _yellowSignalPanel.SetActive(true);
        PlayerPrefs.SetInt("TutorialYellowStage", 1);
    }

    public void HpLoseTutorial()
    {
        Time.timeScale = 0;
        _musicTime = _audioSource.time;
        _audioSource.Stop();
        _hpLosePanel.SetActive(true);
        PlayerPrefs.SetInt("TutorialStage", 2);
    }

    public void StartTime()
    {
        Time.timeScale = 1;
        _audioSource.Play();
        _audioSource.time = _musicTime;
    }

    public void FirstTutStage()
    {
        PlayerPrefs.SetInt("TutorialStage", 1);
    }

    public void TimeButton()
    {
        _secondTutBut.onClick.AddListener(StartTime);
        _secondTutBut.onClick.AddListener(FirstTutStage);
        _thirdTutBut.onClick.AddListener(StartTime);
        _fourthTutBut.onClick.AddListener(StartTime);
        _fifthTutBut.onClick.AddListener(StartTime);
    }
}
