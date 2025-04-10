using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private RitmTimerScript _timerScript;
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private MetreController _metreController;
    [SerializeField] private PlayerBehavior _playerBehavior;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private GameObject _divingTimerObject;
    [SerializeField] private SpriteRenderer _darkerSpriteRenderer;
    [SerializeField] private Slider _timerSlider;
    private Timer _divingTimer;
    private bool _maxTimerValue;
    private float _musicTimerValue;
    private float _sliderMaxValue;
    private float _sliderValue;
    private float _transperency = 0.4f;

    private List<PointsGroup> _pointsGroups;
    private List<Transform> _pointsForGroupTransforms;

    private void Start()
    {
        _musicTimerValue = _timerScript.MusicTimerValue;
        _pointsGroups = PointsViewer.Instance.Points;
        _pointsForGroupTransforms = _spawnController.PointsForGroupTransform;

        _timerSlider.value = _sliderValue;
        _timerSlider.maxValue = _sliderMaxValue;
        _divingTimer = _divingTimerObject.GetComponent<Timer>();
        _divingTimer.MaxTimerValue = 1.8f;
        _divingTimer.StartCountdown();
    }

    private void FixedUpdate()
    {
        _sliderValue = _divingTimer.TimerCurrentTime;
        _sliderMaxValue = _divingTimer.MaxTimerValue;
        _timerSlider.value = _sliderValue;
        _timerSlider.maxValue = _sliderMaxValue;
        _musicTimerValue = _timerScript.MusicTimerValue;

        _maxTimerValue = _divingTimer.ReachingTimerMaxValue;
        _pointsGroups = PointsViewer.Instance.Points;

        if (_maxTimerValue)
        {
            _divingTimer.StopCountdown();

            List<PointsGroup> groupsToRemove = new List<PointsGroup>();
            foreach (PointsGroup groups in _pointsGroups)
            {
                if (groups.transform.position == _pointsForGroupTransforms[5].transform.position)
                {
                    groups.transform.position = _pointsForGroupTransforms[4].transform.position;
                }
                else if (groups.transform.position == _pointsForGroupTransforms[4].transform.position)
                {
                    groups.transform.position = _pointsForGroupTransforms[3].transform.position;
                }
                else if (groups.transform.position == _pointsForGroupTransforms[3].transform.position)
                {
                    groups.transform.position = _pointsForGroupTransforms[2].transform.position;
                }
                else if (groups.transform.position == _pointsForGroupTransforms[2].transform.position)
                {
                    groups.transform.position = _pointsForGroupTransforms[1].transform.position;
                }
                else if (groups.transform.position == _pointsForGroupTransforms[1].transform.position)
                {
                    groups.transform.position = _pointsForGroupTransforms[0].transform.position;
                }
                else if (groups.transform.position == _pointsForGroupTransforms[0].transform.position)
                {
                    Destroy(groups.gameObject);
                    groupsToRemove.Add(groups);
                }
            }

            _spawnController.SpawnPointsGroup();

            foreach (PointsGroup groups in groupsToRemove)
            {
                _pointsGroups.Remove(groups);
            }

            _spawnController.SpawnObjects();
            _playerBehavior.UpdateScore();

            _transperency += 0.003f;
            if (_transperency > 0.9f)
            {
                _transperency = 0.9f;
            }

            Color newColor = new Color(_darkerSpriteRenderer.color.r, _darkerSpriteRenderer.color.g, _darkerSpriteRenderer.color.b, _transperency);
            _darkerSpriteRenderer.color = newColor;


            if (_musicTimerValue <= 22)
            {
                _divingTimer.MaxTimerValue = 2f;
            }
            else if (_musicTimerValue <= 34)
            {
                _divingTimer.MaxTimerValue = 1.7f;
            }
            else if (_musicTimerValue <= 39)
            {
                _divingTimer.MaxTimerValue = 1.3f;
            }
            else if (_musicTimerValue <= 45)
            {
                _divingTimer.MaxTimerValue = 1.1f;
            }
            else if (_musicTimerValue <= 88)
            {
                _divingTimer.MaxTimerValue = 0.6f;
            }
            else if (_musicTimerValue <= 132)
            {
                _divingTimer.MaxTimerValue = 0.7f;
            }
            else if (_musicTimerValue <= 154)
            {
                _divingTimer.MaxTimerValue = 1.3f;
            }
            else if (_musicTimerValue <= 175)
            {
                _divingTimer.MaxTimerValue = 0.7f;
            }
            else if (_musicTimerValue <= 200)
            {
                _divingTimer.MaxTimerValue = 0.6f;
            }
            else if (_musicTimerValue <= 242)
            {
                _divingTimer.MaxTimerValue = 0.3f;
            }

            if (_divingTimer.MaxTimerValue < 0.3)
            {
                _divingTimer.MaxTimerValue = 0.3f;
            }

            _metreController.UpdateMetreText();

                _divingTimer.StartCountdown();
            _playerController.IsMoveAvalible = true;
        }

    }

    public void TimerDeactivate()
    {
        _divingTimer.StopCountdown();
    }
}
