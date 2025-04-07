using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private MetreController _metreController;
    [SerializeField] private PlayerBehavior _playerBehavior;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private GameObject _divingTimerObject;
    [SerializeField] private SpriteRenderer _darkerSpriteRenderer;
    [SerializeField] private Slider _timerSlider;
    private TMP_Text _metrText;
    private Timer _divingTimer;
    private bool _maxTimerValue;
    private float _sliderMaxValue;
    private float _sliderValue;
    private float _transperency = 0.4f;

    private List<PointsGroup> _pointsGroups;
    private List<Transform> _pointsForGroupTransforms;

    private void Start()
    {
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


                _metrText = groups.GetComponentInChildren<TMP_Text>();
                _metrText.transform.position = new Vector2(groups.transform.position.x - 500, groups.transform.position.y);
            }

            _spawnController.SpawnPointsGroup();

            foreach (PointsGroup groups in groupsToRemove)
            {
                _pointsGroups.Remove(groups);
            }

            _spawnController.SpawnObjects();
            _playerBehavior.UpdateScore();

            _transperency += 0.002f;
            if (_transperency > 0.8f)
            {
                _transperency = 0.8f;
            }

            Color newColor = new Color(_darkerSpriteRenderer.color.r, _darkerSpriteRenderer.color.g, _darkerSpriteRenderer.color.b, _transperency);
            _darkerSpriteRenderer.color = newColor;
            
            
            if (_divingTimer.MaxTimerValue > 1)
            {
                _divingTimer.MaxTimerValue -= 0.03f;
            }
            else if (_divingTimer.MaxTimerValue > 0.6)
            {
                _divingTimer.MaxTimerValue -= 0.01f;
            }
            else if (_divingTimer.MaxTimerValue > 0.3)
            {
                _divingTimer.MaxTimerValue -= 0.008f;
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
