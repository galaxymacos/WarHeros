using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public static Chess[,] map;

    public void AddChess(Chess chess)
    {
        int chessX = chess.position.x;
        int chessY = chess.position.y;
        if (map[chessX, chessY] != null)
        {
            map[chessX, chessY] = chess;
        }
    }
}