using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Localozation : MonoBehaviour
{
    //MenuUI

    //GameplayUI
    [SerializeField] TMP_Text _textTutorial1;
    [SerializeField] TMP_Text _buttonTutorial1;
    [SerializeField] TMP_Text _textTutorial2;
    [SerializeField] TMP_Text _buttonTutorial2;
    [SerializeField] TMP_Text _textTutorial3;
    [SerializeField] TMP_Text _buttonTutorial3;
    [SerializeField] TMP_Text _textTutorial4;
    [SerializeField] TMP_Text _buttonTutorial4;
    [SerializeField] TMP_Text _textTutorial5;
    [SerializeField] TMP_Text _buttonTutorial5;

    //ResultUI
    [SerializeField] TMP_Text _textResult;
    [SerializeField] TMP_Text _textRecord;
    [SerializeField] TMP_Text _buttonRestart;
    [SerializeField] TMP_Text _buttonMenu;

    private int _isRussian;

    void Start()
    {
        _isRussian = PlayerPrefs.GetInt("isRussian");

        if (_isRussian == 1)
        {
            _textTutorial1.text = "Добро пожаловать в SignalBit! Ваша задача набрать как можно больше очков. Сфокусируйтесь на сигналах локатора, избегайте препятствий и собирайте бонусы";
            _buttonTutorial1.text = "Далее";
            _textTutorial2.text = "Вы можете двигаться только по горизонтали один раз за тик таймера. Используйте кнопки A и D для управление субмариной. " +
                "Или нажимайте на левую или правую сторону экрана, если играете с телефона";
            _buttonTutorial2.text = "Далее";
            _textTutorial3.text = "Красные круги опасны. Избегайте их!";
            _buttonTutorial3.text = "Далее";
            _textTutorial4.text = "Желтые круги дают дополнительные очки. Собирайте их!";
            _buttonTutorial4.text = "Далее";
            _textTutorial5.text = "Вы столкнулись с препятствием и потеряли ХП. Осторожнее,у вас осталось лишь 2 ХП";
            _buttonTutorial5.text = "Далее";
            _textResult.text = "Субмарина уничтожена!";
            _textRecord.text = "НОВЫЙ РЕКОРД!";
            _buttonRestart.text = "Заново";
            _buttonMenu.text = "Главное меню";
        }
        else
        {
            _textTutorial1.text = "Welcome to SignalBit! Your task is to score as many points as possible.Focusing on the sonar signals, dodge obstacles and collect bonuses";
            _buttonTutorial1.text = "NEXT";
            _textTutorial2.text = "You can only move horizontally, once per timer tick. Use the A and D keys to control the submarine. " +
                "Or click on the left and right sides of the screen for the mobile version";
            _buttonTutorial2.text = "RESUME";
            _textTutorial3.text = "Red circles signal danger. Avoid them!";
            _buttonTutorial3.text = "RESUME";
            _textTutorial4.text = "Yellow circles indicate bonus points. Catch them!";
            _buttonTutorial4.text = "RESUME";
            _textTutorial5.text = "You've hit an obstacle and lost HP. Careful, there are only 2 of them left";
            _buttonTutorial5.text = "RESUME";
            _textResult.text = "Submarine is destroyed!";
            _textRecord.text = "NEW RECORD!";
            _buttonRestart.text = "Restart";
            _buttonMenu.text = "Main Menu";
        }
    }
}
