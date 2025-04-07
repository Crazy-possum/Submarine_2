using System;
using System.Collections;
using System.Collections.Generic;
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

    public List<Transform> PointsForGroupTransform;
    public Vector2 SpawnPositionsVector;
    public GameObject Object;
    public GameObject SpriteGameObject;

    private TransformSercher _transformSercher;
    private GameObject _groupGameObject;


    public void SpawnPointsGroup()
    {
        GameObject gObject = GameObject.Instantiate(_pointsGroup, PointsForGroupTransform[5].position, Quaternion.identity, _rootTransform);
        PointsGroup pointsGroup = gObject.GetComponent<PointsGroup>();

        _groupGameObject = pointsGroup.gameObject;

        PointsViewer.Instance.AddPointsGroup(pointsGroup);
    }

    private void TakeSpawnPointPositions()
    {
        Vector2 position = Vector2.zero;

        System.Random randomForGroup = new System.Random();
        int SpawnChance = randomForGroup.Next(0, 9);

        if (SpawnChance < 7)
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
