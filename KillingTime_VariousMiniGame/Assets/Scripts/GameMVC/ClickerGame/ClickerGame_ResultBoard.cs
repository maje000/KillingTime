using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class ClickerGame_ResultBoard : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    public Button exitButton
    { 
        get
        {
            if (_exitButton != null)
            {
                return _exitButton;
            }

            _exitButton = transform.Find("ButtonHolder/Back").GetComponent<Button>();
            return _exitButton;
        }
    }
    [SerializeField] private Button _restartButton;
    public Button restartButton
    {
        get
        {
            if (_restartButton != null)
            {
                return _restartButton;
            }

            _restartButton = transform.Find("ButtonHolder/Restart").GetComponent<Button>();
            return _restartButton;
        }
    }
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    public TMPro.TextMeshProUGUI scoreText
    {
        get
        {
            if (_scoreText != null)
            {
                return _scoreText;
            }

            _scoreText = transform.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
            return _scoreText;
        }
    }

    private void Reset()
    {
            _exitButton = transform.Find("ButtonHolder/Exit").GetComponent<Button>();
            _restartButton = transform.Find("ButtonHolder/Restart").GetComponent<Button>();
            _scoreText = transform.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
    }
}
