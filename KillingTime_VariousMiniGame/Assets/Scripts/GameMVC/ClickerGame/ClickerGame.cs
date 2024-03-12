using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGame : GameModel
{
    [SerializeField] private int score;
    private Vector2[,] positions = new Vector2[,] {
        {new Vector3(-330f, -330*2f),
        new Vector3(-330f, -330*1f),
        new Vector3(-330f, 330*0f),
        new Vector3(-330f, 330*1f),
        new Vector3(-330f, 330*2f)},
        {new Vector3(0f, -330*2f),
        new Vector3(0f, -330*1f),
        new Vector3(0f, -330*0f),
        new Vector3(0f, -330*1f),
        new Vector3(0f, -330*2f),},
        {new Vector3(330f, -330*2f),
        new Vector3(330f, -330*1f),
        new Vector3(330f, -330*0f),
        new Vector3(330f, -330*1f),
        new Vector3(330f, -330*2f),}
    };

    public Vector2 GetRandomPosition()
    {
        int random = Random.Range(0, positions.Length);

        int randomRow = Random.Range(0, random / positions.Rank);
        int randomColumn = Random.Range(0, random % positions.Rank);
        return positions[randomRow, randomColumn];
    }
}