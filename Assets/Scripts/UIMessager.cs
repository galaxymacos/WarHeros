﻿using System;
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
        GameLoop.instance.currentNurseToMove = index;
    }

    public void MoveUp()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Up);
    }

    public void MoveDown()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Down);
    }
    
    public void MoveLeft()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Left);
    }

    public void MoveRight()
    {
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
}