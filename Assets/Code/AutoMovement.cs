using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoMovement : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private GameObject _divingTimerObject;
    [SerializeField] private Slider _timerSlider;
    private Timer _divingTimer;
    private bool _maxTimerValue;
    private float _sliderValue;

    private List<PointsGroup> _pointsGroups;
    private List<Transform> _pointsForGroupTransforms;

    private void Start()
    {
        _pointsGroups = PointsViewer.Instance.Points;
        _pointsForGroupTransforms = _spawnController.PointsForGroupTransform;

        _timerSlider.value = _sliderValue;
        _divingTimer = _divingTimerObject.GetComponent<Timer>();
        _divingTimer.MaxTimerValue = 2;
        _divingTimer.StartCountdown();
    }

    private void FixedUpdate()
    {
        _sliderValue = _divingTimer.TimerCurrentTime;
        _timerSlider.value = _sliderValue;
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

            _divingTimer.StartCountdown();
            _playerController.IsMoveAvalible = true;
        }

    }
}
