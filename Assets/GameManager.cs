using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Player> players;

    private void Awake()
    {
    }

    private void Start()
    {
        StartGame();
        print("set up accomplished");
        print(players.Count);
        foreach (Player player in players)
        {
            print(player.id + " has a chess of " + player.chess.GetType());
        }
    }


    public void StartGame()
    {
        players = new List<Player>();
        InputData inputData = SaveSystem.LoadPlayer();
        print(inputData.playerNum);
        for (int i = 0; i < inputData.playerNum; i++)
        {
            Player player = new Player {id = i + 1};
            switch (inputData.nurseTypes[i])
            {
                case NurseType.Red:
                    player.chess = new NurseChess(new Position(0,i));
                    break;
                case NurseType.Green:
                    player.chess = new NurseChess(new Position(0,i));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            players.Add(player);
        }
    }
}