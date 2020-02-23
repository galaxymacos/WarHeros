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
        NurseManager.instance.nurses[currentNurseToMove].mobilityCounter -= 1;

        // If the current moving nurse steps on a mine
        if (GameManager.instance.bf.CheckForMine(NurseManager.instance.nurses[currentNurseToMove].position))
        {
            print(
                $"The current player is stepping on the mine at the position of {NurseManager.instance.nurses[currentNurseToMove].position}");
            onNurseStepOnMine?.Invoke(NurseManager.instance.nurses[currentNurseToMove]);
            
            
            
        }
        else if (NurseManager.instance.nurses[currentNurseToMove].mobilityCounter == 0)
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
        SpawnRandomEvent();

        ReplenishNurseMobility();

        if (currentNurseToMove != -1)
        {
            DeselectTheCurrentNurse();
        }
    }

    private void SpawnRandomEvent()
    {
        Events.instance.SelectRandomFunction();
    }

    private static void ReplenishNurseMobility()
    {
        foreach (Nurse nurse in NurseManager.instance.nurses)
        {
            print("Replenish the mobility of the nurse " + nurse.GetType().FullName + " to full");
            nurse.ReplenishMobility();

            if (nurse.skill != null)
            {
                print("Replenish all the skills");
                nurse.skill.Replenish();
            }

            if (nurse.isDefusing)
            {
                nurse.isDefusing = false;
            }
        }
    }


    public void StartGame()
    {
        print("Start the game");
        currentNurseToMove = -1;
    }
    
}