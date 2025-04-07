using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _audioClipBonus;
    [SerializeField] private AudioClip _audioClipObstacle;

    private void Start()
    {
        _audioSource = _audioSource.GetComponent<AudioSource>();
    }

    public void PlayBonusSound()
    {
        _audioSource.PlayOneShot((AudioClip)Resources.Load("Audio/Sound_1"));
    }   
    public void PlayObstacleSound()
    {
        _audioSource.PlayOneShot((AudioClip)Resources.Load("Audio/Sound_2"));
    }
}
