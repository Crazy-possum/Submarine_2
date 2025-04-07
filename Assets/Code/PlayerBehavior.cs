using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreValueText;
    [SerializeField] private Image _threedHpImage;
    [SerializeField] private Image _twoHpImage;
    [SerializeField] private Image _lastHpImage;

    public int Hp;
    public int Score;

    private int _currentHp;

    private void Start()
    {
        Hp = 3;
        Score = 0;
        _currentHp = 3;
    }

    public void LoseHp()
    {
        if (_currentHp > 1)
        {
            _currentHp -= 1;
            UpdateHpImage();
        }
        else 
        {
            _currentHp -= 1;
            UpdateHpImage();
            LoseGame();
        }
    }

    private void UpdateHpImage()
    {
        switch (_currentHp)
        {
            case 0:
                _lastHpImage.enabled = false; 
                break;
            case 1:
                _twoHpImage.enabled = false;
                break;
            case 2:
                _threedHpImage.enabled = false;
                break;
             default:
                break;
        }
    }

    private void LoseGame()
    {

    }

    public void UpdateScore()
    {
        Score += 10;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {

    }
}

