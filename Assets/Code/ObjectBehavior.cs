using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;
    private SignalController _signalController;
    private SpriteRenderer _objectSpriteRenderer;
    private Animator _objectAnimator;

    public PlayerBehavior PlayerBehavior { get => _playerBehavior; set => _playerBehavior = value; }
    public SignalController SignalController { get => _signalController; set => _signalController = value; }

    private void Start()
    {
        _objectSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        _objectAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "BonusObject")
            {
                _playerBehavior.AddBonusScore();
            }
            else if (gameObject.tag == "ObstacleObject")
            {
                _playerBehavior.LoseHp();
            }
        }
        else if (collision.gameObject.tag == "Trigger")
        {
            Debug.Log(_signalController);
            _objectSpriteRenderer.enabled = true;
            _objectAnimator.enabled = true;

            if (gameObject.tag == "BonusObject")
            {
                _signalController.PlayBonusSound();
            }
            else if (gameObject.tag == "ObstacleObject")
            {
                _signalController.PlayObstacleSound();
            }
        }
    }
}
