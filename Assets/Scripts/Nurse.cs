using System;
using System.Collections;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    
    private void Start()
    {
        position = GameManager.instance.bf.getTrenchPosition(0);
        mobilityCounter = mobilityEachTurn;
    }

    // adjustable
    public Sprite sprite;
    
    [Header("Don't change the below variable")]
    public Position position;
    public Skill skill;
    public int mobilityEachTurn = 2;
    public int mobilityCounter;
    public int toughness;
    public bool hasMobility => mobilityCounter > 0;
    public bool canHeal => GameManager.instance.bf.IsThereSoldier(position);

    public bool hasSpawned => position.column >= 0;

    private void Awake()
    {
        // Initialize the position to the trench
        position = new Position(-1,-1);
        
        // set the skill's owner to itself
        if (skill != null)
        {
            skill.owner = this;
        }
    }

    // Heal the soldider in the nurse's position
    public void Heal()
    {
        Heal(position);
    }

    // Heal the soldier at a desired position
    public void Heal(Position checkPosition)
    {
        if (canHeal)
        {
            GameManager.instance.bf.RemoveSoldier(checkPosition);
            // Gain a point for healing a soldier
            GameManager.instance.GainPointForHealingSoldiers();
            if (skill != null)
            {
                skill.Replenish();
                
            }
            GameLoop.instance.onNurseMoveComplete?.Invoke();
        }
    }

    public void SetBirthLocation(int columnIndex)
    {
        print("give birth to the player");
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
                newPosition = new Position(position.row, position.column+1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(nurseMoveDirection), nurseMoveDirection, null);
        }
        // TODO Adrian  
        if (GameManager.instance.bf.IsPosInBoard(newPosition))
        {
            position = newPosition;
            print($"Nurse {NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove]} moves to row {position.row}, column {position.column}");
            UiManager.instance.onLocationChanged?.Invoke(position);
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
        print("try to cast a skill");
        if (skill.IsSkillAvailable())
        {
            print("skill is available");
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

