using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop: MonoBehaviour
{
    public static GameLoop instance;
    
    public List<Nurse> nurses;
    private int currentNurseToMove;

    Action onNurseMoveComplete;

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

    public void CheckNextTurn()
    {
        if (nurses[currentNurseToMove].mobilityCounter == 0)
        {
            NextTurn();
        }
    }

    public void NextTurn()
    {
        currentNurseToMove++;
        if (currentNurseToMove >= nurses.Count)
        {
            currentNurseToMove = 0;
        }
    }
    
}