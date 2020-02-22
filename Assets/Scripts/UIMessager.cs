using System;
using UnityEngine;

public class UIMessager: MonoBehaviour
{
    public static UIMessager instance;

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
        print($"Select nurse {index}");
        GameLoop.instance.currentNurseToMove = index;
        if (!NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].hasSpawned)
        {
            // Open the panel for spawning the nurse
        }
    }

    public void SpawnCurrentNurseTo(int columnIndex)
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].hasSpawned = true;
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].SetBirthLocation(columnIndex);
    }

    public void MoveUp()
    {
        print("Move up ");
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Up);
    }

    public void MoveDown()
    {
        print("Move down ");

        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Down);
    }
    
    public void MoveLeft()
    {
        print("Move left ");

        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Left);
    }

    public void MoveRight()
    {
        print("Move right ");

        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Right);
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