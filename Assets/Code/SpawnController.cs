using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class SpawnController : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    [SerializeField] private PlayerBehavior _playerBehavior;
    [SerializeField] private SignalController _signalController;
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private Transform _objectRootTransform;
    [SerializeField] private GameObject _pointsGroup;
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _bonus;

    [SerializeField] private Sprite _bgGame1;
    [SerializeField] private Sprite _bgGame2;
    [SerializeField] private Sprite _bgGame3;
    [SerializeField] private Sprite _bgGame4;
    [SerializeField] private Sprite _bgGame5;
    [SerializeField] private Sprite _bgGame6;

    [SerializeField] private Sprite _wall1;
    [SerializeField] private Sprite _wall2;
    [SerializeField] private Sprite _wall3;
    [SerializeField] private Sprite _wall4;
    [SerializeField] private Sprite _wall5;
    [SerializeField] private Sprite _wall6;

    public List<Transform> PointsForGroupTransform;
    public Vector2 SpawnPositionsVector;
    public GameObject Object;
    public GameObject SpriteGameObject;

    private TransformSercher _transformSercher;
    private GameObject _groupGameObject;
    private SpriteRenderer _bgSpriteRenderer;
    private SpriteRenderer _leftWallSpriteRenderer;
    private SpriteRenderer _rightWallSpriteRenderer;

    public void SpawnPointsGroup()
    {
        _bgSpriteRenderer = _pointsGroup.GetComponentInChildren<ObjectViewer>().BgSpriteRenderer;
        _leftWallSpriteRenderer = _pointsGroup.GetComponentInChildren<ObjectViewer>().LeftWallSpriteRenderer;
        _rightWallSpriteRenderer = _pointsGroup.GetComponentInChildren<ObjectViewer>().RightWallSpriteRenderer;

        System.Random random = new System.Random();
        int randomInt = random.Next(0, 5);

        switch (randomInt)
        {
            case 0:
                 _bgSpriteRenderer.sprite = _bgGame1;
                break;
            case 1:
                _bgSpriteRenderer.sprite = _bgGame2;
                break;
            case 2:
                _bgSpriteRenderer.sprite = _bgGame3;
                break;
            case 3:
                _bgSpriteRenderer.sprite = _bgGame4;
                break;
            case 4:
                _bgSpriteRenderer.sprite = _bgGame5;
                break;
            case 5:
                _bgSpriteRenderer.sprite = _bgGame6;
                break;
            default:
                break;
        }

        System.Random LWallRandom = new System.Random();
        int LWallRandomInt = LWallRandom.Next(0, 5);

        switch (LWallRandomInt)
        {
            case 0:
                _leftWallSpriteRenderer.sprite = _wall1;
                break;
            case 1:
                _leftWallSpriteRenderer.sprite = _wall2;
                break;
            case 2:
                _leftWallSpriteRenderer.sprite = _wall3;
                break;
            case 3:
                _leftWallSpriteRenderer.sprite = _wall4;
                break;
            case 4:
                _leftWallSpriteRenderer.sprite = _wall5;
                break;
            case 5:
                _leftWallSpriteRenderer.sprite = _wall6;
                break;
            default:
                break;
        }

        System.Random RWallRandom = new System.Random();
        int RWallRandomInt = RWallRandom.Next(0, 5);

        switch (RWallRandomInt)
        {
            case 0:
                _rightWallSpriteRenderer.sprite = _wall1;
                _rightWallSpriteRenderer.flipX = true;
                break;
            case 1:
                _rightWallSpriteRenderer.sprite = _wall2;
                _rightWallSpriteRenderer.flipX = true;
                break;
            case 2:
                _rightWallSpriteRenderer.sprite = _wall3;
                _rightWallSpriteRenderer.flipX = true;
                break;
            case 3:
                _rightWallSpriteRenderer.sprite = _wall4;
                _rightWallSpriteRenderer.flipX = true;
                break;
            case 4:
                _rightWallSpriteRenderer.sprite = _wall5;
                _rightWallSpriteRenderer.flipX = true;
                break;
            case 5:
                _rightWallSpriteRenderer.sprite = _wall6;
                _rightWallSpriteRenderer.flipX = true;
                break;
            default:
                break;
        }

        GameObject gObject = GameObject.Instantiate(_pointsGroup, PointsForGroupTransform[5].position, Quaternion.identity, _rootTransform);
        PointsGroup pointsGroup = gObject.GetComponent<PointsGroup>();

        _groupGameObject = pointsGroup.gameObject;

        PointsViewer.Instance.AddPointsGroup(pointsGroup);
    }

    private void TakeSpawnPointPositions()
    {
        Vector2 position = Vector2.zero;

        System.Random randomForGroup = new System.Random();
        int SpawnChance = randomForGroup.Next(1, 100);

        if (SpawnChance < 75)
        {
            _transformSercher = _groupGameObject.GetComponent<TransformSercher>();

            System.Random randomSpawnPoint = new System.Random();
            int transformIndex = randomSpawnPoint.Next(0, 5);

            switch (transformIndex)
            {
                case 0:
                    position = _transformSercher.PoinsTransformList[0].position;
                    break;
                case 1:
                    position = _transformSercher.PoinsTransformList[1].position;
                    break;
                case 2:
                    position = _transformSercher.PoinsTransformList[2].position;
                    break;
                case 3:
                    position = _transformSercher.PoinsTransformList[3].position;
                    break;
                case 4:
                    position = _transformSercher.PoinsTransformList[4].position;
                    break;
                default:
                    break;
            }

            SpawnPositionsVector = position;
        }
    }

    public void SpawnObjects()
    {
        TakeSpawnPointPositions();
        
        if (SpawnPositionsVector != Vector2.zero)
        {
            System.Random objectTypeandom = new System.Random();
            int objectSpawnChance = objectTypeandom.Next(0, 9);

            if (objectSpawnChance < 6)
            {
                GameObject sceneGObject = GameObject.Instantiate(_obstacle, SpawnPositionsVector, Quaternion.identity, _groupGameObject.transform);
                Object = sceneGObject;
                SpriteGameObject = Object.GetComponentInChildren<SpriteRenderer>().gameObject;
                //SpriteGameObject.SetActive(false);
            }
            else
            {
                GameObject sceneGObject = GameObject.Instantiate(_bonus, SpawnPositionsVector, Quaternion.identity, _groupGameObject.transform);
                Object = sceneGObject;
                SpriteGameObject = Object.GetComponentInChildren<SpriteRenderer>().gameObject;
               // SpriteGameObject.SetActive(false);
            }

            Object.GetComponent<ObjectBehavior>().PlayerBehavior = _playerBehavior;
            Object.GetComponent<ObjectBehavior>().SignalController = _signalController;
            _playerBehavior._bonusScoreText.gameObject.SetActive(false);
        }

        SpawnPositionsVector = Vector2.zero;
    }
}
