using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MetreController : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstMetrePosition;
    [SerializeField] private TMP_Text _secondMetrePosition;
    [SerializeField] private TMP_Text _thirdMetrePosition;
    [SerializeField] private TMP_Text _fouthMetrePosition;

    public int MetreRecord;

    private int _firstMetreValue;
    private int _secondMetreValue;
    private int _thirdMetreValue;
    private int _fouthMetreValue;

    private void Start()
    {
        _firstMetreValue = 4;
        _secondMetreValue = 3;  
        _thirdMetreValue = 2;
        _fouthMetreValue = 1;
    }

    public void UpdateMetreText()
    {
        _firstMetreValue += 1;
        _firstMetrePosition.text = $"{_firstMetreValue} m";
        _secondMetreValue += 1;
        _secondMetrePosition.text = $"{_secondMetreValue} m";
        _thirdMetreValue += 1;
        _thirdMetrePosition.text = $"{_thirdMetreValue} m";
        MetreRecord = _thirdMetreValue;
        _fouthMetreValue += 1;
        _fouthMetrePosition.text = $"{_fouthMetreValue} m";
    }
}
