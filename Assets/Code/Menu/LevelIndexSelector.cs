using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelIndexSelector : MonoBehaviour
{
    [SerializeField] private LevelInfoUpdate _levelInfoUpdate;
    
    [SerializeField] private List<GameObject> _levelObjectList;
    [SerializeField] private GameObject _nextLevelSercher;
    [SerializeField] private GameObject _pastLevelSercher;

    public int CurrentIndex;

    private Transform _nextlevelSercherTransform;
    private Transform _pastlevelSercherTransform;

    private void Start()
    {
        _nextlevelSercherTransform = _nextLevelSercher.GetComponent<Transform>();
        _pastlevelSercherTransform = _pastLevelSercher.GetComponent<Transform>();
        CurrentIndex = 0;
    }

    private void Update()
    {
        CheckCurrentLevel();
    }

    private void CheckCurrentLevel()
    {
        if (CurrentIndex + 1 < _levelObjectList.Count)
        {
            float nextLevelSercherPos = _nextlevelSercherTransform.position.y; 

            Transform nextLevelObjectTransform;
            nextLevelObjectTransform = _levelObjectList[CurrentIndex + 1].GetComponent<Transform>();
            float nextLevelObjectPos = nextLevelObjectTransform.position.y;

            if (nextLevelObjectPos >= nextLevelSercherPos)
            {
                CurrentIndex++;
                _levelInfoUpdate.UpdateInfo();
            }
        }

        if (CurrentIndex > 0)
        {
            float pastLevelSercherPos = _pastlevelSercherTransform.position.y;

            Transform pastLevelObjectTransform;
            pastLevelObjectTransform = _levelObjectList[CurrentIndex - 1].GetComponent<Transform>();
            float pastLevelObjectPos = pastLevelObjectTransform.position.y;

            if (pastLevelObjectPos <= pastLevelSercherPos)
            {
                CurrentIndex--;
                _levelInfoUpdate.UpdateInfo();
            }
        }
    }
}
