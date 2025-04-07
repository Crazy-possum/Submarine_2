using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmTimerScript : MonoBehaviour
{
    [SerializeField] private GameObject _ritmTimerObject;

    public float MusicTimerValue;

    private Timer _ritmTimer;
    private bool _maxTimerValue;

    private void Start()
    {
        _ritmTimer = _ritmTimerObject.GetComponent<Timer>();
        _ritmTimer.MaxTimerValue = 242f;
        _ritmTimer.StartCountdown();
    }

    private void Update()
    {
        MusicTimerValue = _ritmTimer.TimerCurrentTime;
        _maxTimerValue = _ritmTimer.ReachingTimerMaxValue;

        if (_maxTimerValue)
        {
            _ritmTimer.StopCountdown();
            MusicTimerValue = 0;
            _ritmTimer.StartCountdown();
        }
    }
}
