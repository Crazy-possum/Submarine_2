using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoUpdate : MonoBehaviour
{
    [SerializeField] private LevelIndexSelector _levelIndexSelector;
    [SerializeField] private SceneLoader _sceneLoader;
    
    [SerializeField] private List<string> _levelNames;
    [SerializeField] private TMP_Text _levelName;

    private int _currentLevelIndex;

    private void Start()
    {
        _currentLevelIndex = _levelIndexSelector.CurrentIndex;
        _levelName.text = _levelNames[_currentLevelIndex];
        _sceneLoader.Index = _currentLevelIndex + 2;
    }

    public void UpdateInfo()
    {
        _currentLevelIndex = _levelIndexSelector.CurrentIndex;
        _levelName.text = _levelNames[_currentLevelIndex];
        _sceneLoader.Index = _currentLevelIndex + 2;
    }
}
