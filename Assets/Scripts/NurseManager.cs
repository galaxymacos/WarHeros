using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseManager : MonoBehaviour
{
    public List<Nurse> nurses;

    public static NurseManager instance;

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

    private void Start()
    {
        GameLoop.onNurseStepOnMine += TakeDamage;

    }

    public bool HasNurseInPosition(Position position)
    {
        foreach (Nurse nurse in nurses)
        {
            if (nurse.position.column == position.column && nurse.position.row == position.row)
            {
                return true;
            }
        }

        return false;
    }

    public void TakeDamage(Nurse nurse)
    {
        if (nurse.toughness > 0)
        {
            nurse.toughness--;       
            GameManager.instance.NurseStepsOnMineWithToughness();
        }
        else
        {
            GameManager.instance.NurseStepsOnMine();
        }
        
        // Move the player back to trench
        print("Move the player back to trench because he steps on a mine");
        nurses[GameLoop.instance.currentNurseToMove].MoveNurseBackToTrench();
        
    }
    
}
