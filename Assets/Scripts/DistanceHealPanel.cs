using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceHealPanel : MonoBehaviour
{
    //matrix of buttons
    [SerializeField] Button[] matrixButtons;
    //sprite for the soldier
    [SerializeField] Sprite soldierSprite;
    List<Position> toCheck = new List<Position>();

    public void ActivatePanel()
    {
        //TODO : implement a distance heal method in the nurses' heal
        Position pos = NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position;
        //change images accordingly
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

        for (int i = 0; i < toCheck.Count; i++)
        {
            toCheck[i] = new Position(toCheck[i].column, toCheck[i].row);
            // tocheck[i] == 0 means that it returns a soldier
            if (GameManager.instance.bf.AdvencedCheckForMine(toCheck[i]) == 0)
            {
                //change the image and activate the button
                matrixButtons[i].gameObject.SetActive(true);
                matrixButtons[i].image.sprite = soldierSprite;
            }
        }
    }

    public void HealSoldier(int positionInt)
    {
        /*positionInt is a range of 0 to 8 (1 to 9) to know which button was pressed (0 is top left button, 8 is bottom right)*/
        Position pos = new Position(toCheck[positionInt].row, toCheck[positionInt].column);
        //then, use the newly created position to heal the soldier
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Heal(pos);
        DeactivatePanel();
    }

    private void DeactivatePanel()
    {
        toCheck.Clear();
        foreach(var item in matrixButtons)
        {
            item.image.sprite = null;
        }
        gameObject.SetActive(false);
    }
}
