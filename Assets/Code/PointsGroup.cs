using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGroup : MonoBehaviour
{
    [SerializeField] private GameObject Group;
    [SerializeField] private Transform GroupTransform;

    private void Start()
    {
        GroupTransform = GetComponent<Transform>();
    }
}
