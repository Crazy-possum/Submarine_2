using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;

    public bool IsMoveAvalible;

    [SerializeField] private GameObject _inputPanel;
    [SerializeField] private Button _leftBut;
    [SerializeField] private Button _rightBut;
    private Action _onPlayerEnterTrigger;

    public Action OnPlayerEnterTrigger { get => _onPlayerEnterTrigger; set => _onPlayerEnterTrigger = value; }

    private void Start()
    {
        bool isWebGLOnMobile = Application.isMobilePlatform && Application.platform == RuntimePlatform.WebGLPlayer;

        if (isWebGLOnMobile)
        {
            ActivateMobileInput();
        }
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (IsMoveAvalible)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToRight();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToLeft();
            }
        }
    }

    private void MoveToRight()
    {
        if (gameObject.transform.position.x != 5)
        {
            _playerSpriteRenderer.flipX = true;
            gameObject.transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
            IsMoveAvalible = false;
        }      
    }

    private void MoveToLeft()
    {
        if (gameObject.transform.position.x != -5)
        {
            _playerSpriteRenderer.flipX = false;
            gameObject.transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y);
            IsMoveAvalible = false;
        }
    }

    private void ActivateMobileInput()
    {
        _inputPanel.gameObject.SetActive(true);
        _leftBut.onClick.AddListener(MoveToLeft);
        _rightBut.onClick.AddListener(MoveToRight);
    }
}
