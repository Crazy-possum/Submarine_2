using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    public bool IsMoveAvalible;
    private Action _onPlayerEnterTrigger;

    public Action OnPlayerEnterTrigger { get => _onPlayerEnterTrigger; set => _onPlayerEnterTrigger = value; }


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
                IsMoveAvalible = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToLeft();
                IsMoveAvalible = false;
            }
        }
    }

    private void MoveToRight()
    {
        if (gameObject.transform.position.x != 5)
        {
            _playerSpriteRenderer.flipX = true;
            gameObject.transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
        }      
    }

    private void MoveToLeft()
    {
        if (gameObject.transform.position.x != -5)
        {
            _playerSpriteRenderer.flipX = false;
            gameObject.transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y);
        }
    }
}
