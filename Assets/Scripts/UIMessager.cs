using System;
using UnityEngine;

public class UIMessager: MonoBehaviour
{
    public static UIMessager instance;


    private void Update()
    {

        // if (GameLoop.instance.currentNurseToMove != -1)
        // {
            // print(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].mobilityCounter);
        // }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Action<Position> onInvalidNursePosition;
    
    public void SelectNurse(int index)
    {
        GameLoop.instance.currentNurseToMove = index;
        if (!NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].hasSpawned)
        {
            print($"Nurse {index} has not spawned");
            print($"Temporarily spawn your nurse to the column "+4);
            SpawnCurrentNurseTo(4);
        }

        if (GameLoop.instance.currentNurseToMove != -1)
        {
            UiManager.instance.onLocationChanged?.Invoke(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position);
        }
    }

    public void SpawnCurrentNurseTo(int columnIndex)
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].SetBirthLocation(columnIndex);
        print("Spawn current nurse to the column "+columnIndex);
    }

    public void MoveUp()
    {
        print("Move up ");
        if (GameLoop.instance.currentNurseToMove != -1)
        {
            NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Up);
        }
        else
        {
            print("You don't have mobility in this turn");
        }
    }

    public void MoveDown()
    {
        print("Move down ");

        if (GameLoop.instance.currentNurseToMove != -1)
        {
            NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Down);
        }
        else
        {
            print("You don't have mobility in this turn");
        }
    }
    
    public void MoveLeft()
    {
        print("Move left ");

        if (GameLoop.instance.currentNurseToMove != -1)
        {
            NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Left);
        }
        else
        {
            print("You don't have mobility in this turn");
        }
    }

    public void MoveRight()
    {
        print("Move right ");

        if (GameLoop.instance.currentNurseToMove != -1)
        {
            NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Right);
        }
        else
        {
            print("You don't have mobility in this turn");
        }
    }

    public void CastSkill()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].CastSkill();
    }

    public void Heal()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Heal();
    }

    public int GetRegiemnetLives()
    {
        return GameManager.instance.RegimenLives;
    }

    public int GetSoldiersAlive()
    {
        return GameManager.instance.soldiersToSave;
    }

    public Sprite GetCurrentNurseSprite()
    {
        return NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].sprite;
    }

    public Position GetCurrentNursePosition()
    {
        return NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position;
    }

    public int GetCurrentNurseMobility()
    {
        return NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].mobilityCounter;
    }

    public int GetTheCurrentNurseIndex()
    {
        return GameLoop.instance.currentNurseToMove;
    }
}