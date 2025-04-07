using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private AutoMovement _autoMovement;

    [SerializeField] private ResultePanel _resulePanel;
    [SerializeField] private GameObject _popUpTimerObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _objectGroups;
    [SerializeField] private GameObject _guiPanel;
    [SerializeField] private TMP_Text _scoreValueText;
    [SerializeField] public TMP_Text _bonusScoreText;
    [SerializeField] private GameObject _threedHpImage;
    [SerializeField] private GameObject _twoHpImage;
    [SerializeField] private GameObject _lastHpImage;

    public int Hp;
    public int Score;

    private Timer _popUpTimer;
    private bool _maxTimerValue;
    private int _currentHp;

    private void Start()
    {
        Hp = 3;
        Score = 0;
        _currentHp = 3;

        UpdateScoreText();
    }
    private void Update()
    {
        if (_currentHp == 0 )
        {
            LoseGame();
        }
    }

    public void LoseHp()
    {
        _currentHp -= 1;
        UpdateHpImage();
    }

    private void UpdateHpImage()
    {
        switch (_currentHp)
        {
            case 0:
                _lastHpImage.GetComponent<Animator>().enabled = true;
                break;
            case 1:
                _twoHpImage.GetComponent<Animator>().enabled = true;
                break;
            case 2:
                _threedHpImage.GetComponent<Animator>().enabled = true;
                break;
             default:
                break;
        }
    }

    private void LoseGame()
    {
        _autoMovement.TimerDeactivate();
        _player.SetActive(false);
        _objectGroups.SetActive(false);
        _guiPanel.SetActive(false);
        _resulePanel.OpenResultPanel();
    }

    public void UpdateScore()
    {
        Score += 10;
        UpdateScoreText();
    }

    public void AddBonusScore()
    {
        Score += 25;
        UpdateScoreText();
        UpdateBonusScoreText();
    }    

    private void UpdateScoreText()
    {
        _scoreValueText.text = $"Score: {Score}";
    }

    private void UpdateBonusScoreText()
    {
        _bonusScoreText.gameObject.SetActive(true);
        _bonusScoreText.text = "+ 25";
    }
}

