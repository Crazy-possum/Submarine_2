using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;

    public PlayerBehavior PlayerBehavior { get => _playerBehavior; set => _playerBehavior = value; }

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
    }
}
