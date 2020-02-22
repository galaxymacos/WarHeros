using System;
using System.Collections;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    
    private void Awake()
    {
        position = GameManager.instance.bf.getTrenchPosition(0);
        // TODO skill.owner = this; For Theo to implement
    }

    // adjustable
    public Sprite sprite;
    
    [Header("Don't change the below variable")]
    public Position position;
    public Skill skill;
    public int mobilityEachTurn;
    public int mobilityCounter = 0;
    public bool canMove => mobilityCounter > 0;
    public bool canHeal => GameManager.instance.bf.IsThereSoldier(position);

    public Action onNurseMoveComplete;

    
    // Heal the soldider in the nurse's position
    public void Heal()
    {
        if (canHeal)
        {
            GameManager.instance.bf.RemoveSoldier(position);
        }
        skill.Replenish();
    }

    // Heal the soldier at a desired position
    public void Heal(Position checkPosition)
    {
        if (canHeal)
        {
            GameManager.instance.bf.RemoveSoldier(checkPosition);
        }
        skill.Replenish();
    }

    public void Move(NurseMoveDirection nurseMoveDirection)
    {
        Position newPosition;
        switch (nurseMoveDirection)
        {
            case NurseMoveDirection.Up:
                newPosition = new Position(position.row+1, position.column);
                // GameManager.instance.WallAtPosition(Position position);
                break;
            case NurseMoveDirection.Down:
                newPosition = new Position(position.row-1, position.column);
                break;
            case NurseMoveDirection.Left:
                newPosition = new Position(position.row, position.column-1);
                break;
            case NurseMoveDirection.Right:
                newPosition = new Position(position.row+1, position.column+1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(nurseMoveDirection), nurseMoveDirection, null);

               
        }
        // TODO Adrian  
        if (GameManager.instance.bf.IsPosInBoard(newPosition))
        {
            position = newPosition;
        }
        else
        {
            UIMessager.instance.onInvalidNursePosition?.Invoke(newPosition);
        }



        GameLoop.instance.onNurseMoveComplete?.Invoke();
    }

    public void ReplenishMobility()
    {
        mobilityCounter = mobilityEachTurn;
    }

    // public void CastSkill()
    // {
    //     // TODO skill 
    //     // if ()
    //     {
    //     // mobilityCounter--;
    //     // GameLoop.instance.onNurseMoveComplete?.Invoke();
    //
    //     // }
    // }



}


public enum GameState{
    Nurse1, Nurse2, Nurse3, Nurse4
}

public enum NurseMoveDirection{
    Up,Down,Left,Right
}

