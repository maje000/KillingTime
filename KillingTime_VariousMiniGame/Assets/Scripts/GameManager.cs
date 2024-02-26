using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    [SerializeField] private Game _currentGame;
    [SerializeField] private Game[] _games;

    void Awake() => s_instance = this;
    void Start()
    {
        for (int i = 0; i < _games.Length; i++)
        {
            _games[i].Initialize();
            _games[i].Hide();
        }
    }

    public static void PlayGame<T>() where T : Game
    {
        if (s_instance._currentGame != null)
        {
            CloseGame();
        }

        for (int i = 0; i < s_instance._games.Length; i++)
        {
            if (s_instance._games[i] is T tGame)
            {
                tGame.Show();

                s_instance._currentGame = tGame;
            }
        }
    }

    public static void CloseGame()
    {
        if (s_instance._currentGame != null)
        {
            s_instance._currentGame.Hide();
            
            s_instance._currentGame = null;
        }
    }
}