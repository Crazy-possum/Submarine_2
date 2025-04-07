using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;
    private Action onCollidePlayer;

    public Action OnCollidePlayer { get => onCollidePlayer; set => onCollidePlayer = value; }
    public PlayerBehavior PlayerBehavior { get => _playerBehavior; set => _playerBehavior = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerBehavior.LoseHp();
        }
    }
}
