using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineDetectionPanel : MonoBehaviour
{
    [SerializeField] Image[] matrix;
    [SerializeField] Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        //get nurse location
        //Position pos = NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position;
        Position pos = new Position(6, 6);
        //detect mines around
        List<Position> area = GameManager.instance.bf.GetMineArroundPosition(pos);
        //change images accordingly
        List<Position> toCheck = new List<Position>();
        //tiles above
        toCheck.Add(new Position(pos.column - 1, pos.row + 1));
        toCheck.Add(new Position(pos.column, pos.row + 1));
        toCheck.Add(new Position(pos.column + 1, pos.row + 1));
        //tiles to the sides
        toCheck.Add(new Position(pos.column - 1, pos.row));
        toCheck.Add(pos);
        toCheck.Add(new Position(pos.column + 1, pos.row));
        //tiles below
        toCheck.Add(new Position(pos.column - 1, pos.row - 1));
        toCheck.Add(new Position(pos.column, pos.row - 1));
        toCheck.Add(new Position(pos.column + 1, pos.row - 1));
        

        foreach (var e in area)
        {
            Debug.Log(e.column + ", " + e.row);
        }

        //for (int i = 0; i < toCheck.Count; i++)
        //{
        //    toCheck[i] = new Position(toCheck[i].column, toCheck[i].row);
        //}

        for (int i = 0; i < toCheck.Count; i++)
        {
            toCheck[i] = new Position(toCheck[i].column, toCheck[i].row);

            if (GameManager.instance.bf.AdvencedCheckForMine(toCheck[i]) == -1)
            {
                matrix[i].color = Color.clear;
            }

            else if (GameManager.instance.bf.AdvencedCheckForMine(toCheck[i]) == 1)
            {
                matrix[i].sprite = sprites[0];
            }
            
        }
    }

}
