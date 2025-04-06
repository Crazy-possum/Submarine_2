using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public class SpawnController : MonoBehaviour
{
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private GameObject _pointsGroup;

    public List<Transform> PointsForGroupTransform;
    public int CurrentPointIndex;


    public void SpawnPointsGroup()
    {
        GameObject gObject = GameObject.Instantiate(_pointsGroup, PointsForGroupTransform[5].position, Quaternion.identity, _rootTransform);
        PointsGroup pointsGroup = gObject.GetComponent<PointsGroup>();

        PointsViewer.Instance.AddPointsGroup(pointsGroup);
        CurrentPointIndex = 5;
    }
}
