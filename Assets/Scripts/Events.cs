using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    void ArtilleryStrike()
    {
        //get random position and detect mines around the position
        Position pos = GameManager.instance.bf.GetRandomPosInBoard(false);
        List<Position> area = new List<Position>();
        //tiles above
        area.Add(new Position(pos.column - 1, pos.row + 1));
        area.Add(new Position(pos.column, pos.row + 1));
        area.Add(new Position(pos.column + 1, pos.row + 1));
        //tiles below
        area.Add(new Position(pos.column - 1, pos.row - 1));
        area.Add(new Position(pos.column, pos.row - 1));
        area.Add(new Position(pos.column + 1, pos.row - 1));
        //tiles to the sides
        area.Add(new Position(pos.column - 1, pos.row));
        area.Add(new Position(pos.column + 1, pos.row));
        //destroy mines that were detected and injure soldiers and nurses in the area
        foreach (var a in area)
        {
            GameManager.instance.bf.Demine(a);

            if (GameManager.instance.bf.IsThereSoldier(a))
            {
                GameManager.instance.SoldierDie();
                GameManager.instance.bf.RemoveSoldier(a);
            }

            if (NurseManager.instance.HasNurseInPosition(a))
            {
                GameManager.instance.NurseDie();
            }
        }

    }

    void HailOfBullets()
    {
        //get random position
        Position pos = GameManager.instance.bf.GetRandomPosInBoard(false);
        //select the column
        int col = pos.column;
        //get range (row)
        int range = 6;
        //injure soldiers and nurses in the area

        List<Position> area = new List<Position>();

        for (int i = 0; i < range; i++)
        {
            area.Add(new Position(col, GameManager.instance.bf.depth - i));
        }

        foreach (var a in area)
        {
            GameManager.instance.bf.Demine(a);

            if (GameManager.instance.bf.IsThereSoldier(a))
            {
                GameManager.instance.SoldierDie();
                GameManager.instance.bf.RemoveSoldier(a);
            }

            if (NurseManager.instance.HasNurseInPosition(a))
            {
                GameManager.instance.NurseDie();
            }
        }
    }

    void SpawnMine()
    {
        //spawn a mine in a random unoccupied space
        GameManager.instance.bf.SpawnEntities(1, BattleField.Entities.mine);
    }

    void SpawnSoldier()
    {
        //spawn a soldier in a random unoccupied space
        GameManager.instance.bf.SpawnEntities(1, BattleField.Entities.soldier);
    }
}
