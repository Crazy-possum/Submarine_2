using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocalizationController : MonoBehaviour
{
    [SerializeField] private MainMenu _menu;
    
    [SerializeField] private TMP_Text _textPlay;

    [SerializeField] private Button _en;
    [SerializeField] private Button _ru;

    void Start()
    {
       ChangeLanguage();
       _en.onClick.AddListener(ChangeToEnglish);
       _ru.onClick.AddListener(ChangeToRussian);
    }

    private void OnDestroy()
    {
        _en.onClick.RemoveListener(ChangeToEnglish);
        _ru.onClick.RemoveListener(ChangeToRussian);
    }

    private void ChangeToEnglish()
    {
        PlayerPrefs.SetInt("isRussian", 0);
        ChangeLanguage();
    }

    private void ChangeToRussian()
    {
        PlayerPrefs.SetInt("isRussian", 1);
        ChangeLanguage();
    }

    private void ChangeLanguage()
    {
        if (PlayerPrefs.GetInt("isRussian") == 1)
        {   
            _textPlay.text = "»√–¿“‹";
        }
        else
        {
            _textPlay.text = "PLAY";
        }
        _menu.ShowBestScore();
    }
}
