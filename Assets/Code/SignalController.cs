using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    [SerializeField] private TutorialController _tutController;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private AudioSource _bonusAudioSource;
    [SerializeField] private AudioSource _obstacleAudioSource;

    [SerializeField] private AudioClip _audioClipBonus;
    [SerializeField] private AudioClip _audioClipObstacle;

    private void Start()
    {
        _bonusAudioSource = _bonusAudioSource.GetComponent<AudioSource>();
        _obstacleAudioSource = _obstacleAudioSource.GetComponent<AudioSource>();
    }

    public void PlayBonusSound()
    {
        _bonusAudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/BonusSound"));

        if (PlayerPrefs.GetInt("TutorialYellowStage") != 1)
        {
            _tutController.YellowSignalTutorial();
        }
    }   
    public void PlayObstacleSound()
    {
        _obstacleAudioSource.PlayOneShot((AudioClip)Resources.Load("Audio/ObstacleSound"));

        if (PlayerPrefs.GetInt("TutorialRedStage") != 1)
        {
            _tutController.RedSignalTutorial();
        }
    }
}
