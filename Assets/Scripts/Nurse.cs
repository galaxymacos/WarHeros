using System;
using System.Collections;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    
    private void Awake()
    {
        position = GameManager.instance.bf.getTrenchPosition(0);
        mobilityCounter = mobilityEachTurn;
    }

    // adjustable
    public Sprite sprite;
    
    [Header("Don't change the below variable")]
    public Position position;
    public Skill skill;
    public int mobilityEachTurn;
    public int mobilityCounter = 0;
    public int toughness;
    public bool hasMobility => mobilityCounter > 0;
    public bool canHeal => GameManager.instance.bf.IsThereSoldier(position);

    public bool hasSpawned;


    
    // Heal the soldider in the nurse's position
    public void Heal()
    {
        if (canHeal)
        {
            GameManager.instance.bf.RemoveSoldier(position);
            skill.Replenish();
            GameLoop.instance.onNurseMoveComplete?.Invoke();
        }
    }

    // Heal the soldier at a desired position
    public void Heal(Position checkPosition)
    {
        if (canHeal)
        {
            GameManager.instance.bf.RemoveSoldier(checkPosition);        
            skill.Replenish();
            GameLoop.instance.onNurseMoveComplete?.Invoke();
        }
    }

    public void SetBirthLocation(int columnIndex)
    {
        hasSpawned = true;
        position = new Position(0, columnIndex);
    }

    public void Move(NurseMoveDirection nurseMoveDirection)
    {
        Position newPosition;
        switch (nurseMoveDirection)
        {
            case NurseMoveDirection.Up:
                newPosition = new Position(position.row+1, position.column);
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
            print($"Nurse {NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove]} moves to row {position.row}, column {position.column}");
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

    public void CastSkill()
    {
        if (skill.IsSkillAvailable())
        {
            skill.Activate();
        }
        GameLoop.instance.onNurseMoveComplete?.Invoke();
    }

    public void MoveNurseBackToTrench()
    {
        position = GameManager.instance.bf.getTrenchPosition(0);    // TODO move to the near trench
    }



}


public enum GameState{
    Nurse1, Nurse2, Nurse3, Nurse4
}

public enum NurseMoveDirection{
    Up,Down,Left,Right
}

