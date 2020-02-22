using System;
using System.Collections;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    private void Awake()
    {
        // TODO position = GameManager.instance.GetTrenchPosition(0);
        // TODO skill.owner = this; For Theo to implement
    }

    // adjustable
    public Sprite sprite;
    
    // 
    public Position position;
    public Skill skill;
    public int mobilityEachTurn;
    public int mobilityCounter = 0;
    public bool canMove => mobilityCounter > 0;
    public bool canHeal => GameManager.instance.bf.IsThereSoldier(position);

    
    public void Heal()
    {
        // if (canHeal)
        // {
        //     RemoveSoldierFromBattleField(position);
        // }
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

                // bool canMoveTo = !GameManager.instance.WallAtPosition(newPosition);
                // if (canMoveTo)
                // {
                //
                // position = newPosition;
                // moveCompleted();
            // }
                // else
            // {
                // UIMessager.instance.onInvalidNursePosition?.Invoke(newPosition);
            // }
        }
    }

    public void ReplenishMobility()
    {
        mobilityCounter = mobilityEachTurn;
    }

    // public void CastSkill()
    // {
        // skill.Activate(this);
    // }



}


public enum GameState{
    Nurse1, Nurse2, Nurse3, Nurse4
}

public enum NurseMoveDirection{
    Up,Down,Left,Right
}

