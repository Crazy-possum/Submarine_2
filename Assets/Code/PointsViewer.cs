using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointsViewer : MonoBehaviour
{
    private static PointsViewer _instance;
    
    public List<PointsGroup> Points;
    public List<Transform> PointGroupTransform;



    public static PointsViewer Instance { get => _instance; }

    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Points = new List<PointsGroup>();
    }

    public void AddPointsGroup(PointsGroup pointsGroup)
    {
        Points.Add(pointsGroup);
    }
}
