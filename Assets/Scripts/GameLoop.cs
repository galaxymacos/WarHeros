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
    }

    public void DeselectTheCurrentNurse()
    {
        currentNurseToMove = -1;
    }

   

    public void NextTurn()
    {
        currentNurseToMove++;
        if (currentNurseToMove >= NurseManager.instance.nurses.Count)
        {
            currentNurseToMove = 0;
        }
        
        NurseManager.instance.nurses[currentNurseToMove].ReplenishMobility();
    }
    
    

    public void StartGame()
    {
        DeselectTheCurrentNurse();
    }
    
}