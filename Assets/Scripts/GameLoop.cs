using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop: MonoBehaviour
{
    public static GameLoop instance;
    
    public int currentNurseToMove;

    public Action onNurseMoveComplete;
    public static Action<Nurse> onNurseStepOnMine;

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

        onNurseMoveComplete += NurseMoveComplete;
        
        StartGame();
    }
    
    public void NurseMoveComplete()
    {
        // If the current moving nurse steps on a mine
        if (GameManager.instance.bf.CheckForMine(NurseManager.instance.nurses[currentNurseToMove].position))
        {
            onNurseStepOnMine?.Invoke(NurseManager.instance.nurses[currentNurseToMove]);
            
            
            DeselectTheCurrentNurse();
        }

        NurseManager.instance.nurses[currentNurseToMove].mobilityCounter -= 1;
        
        if (NurseManager.instance.nurses[currentNurseToMove].mobilityCounter == 0)
        {
            DeselectTheCurrentNurse();
        }


        if (AreNursesFinishMovement())
        {
            NextRound();
        }
        
    }

    public void DeselectTheCurrentNurse()
    {
        NurseManager.instance.nurses[currentNurseToMove].mobilityCounter = 0;
        currentNurseToMove = -1;
    }
    public bool AreNursesFinishMovement()
    {
        foreach (Nurse nurse in NurseManager.instance.nurses)
        {
            if (nurse.hasMobility)
            {
                return false;
            }
        }

        return true;
    }
    public void NextRound()
    {
        foreach (Nurse nurse in NurseManager.instance.nurses)
        {
            nurse.ReplenishMobility();
        }
        
        DeselectTheCurrentNurse();
    }
    
    

    public void StartGame()
    {
        print("Start the game");
        DeselectTheCurrentNurse();
    }
    
}