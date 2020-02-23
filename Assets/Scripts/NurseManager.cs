using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseManager : MonoBehaviour
{
    public List<Nurse> nurses;

    public static NurseManager instance;

    public GameObject explosion;
    public Transform explosePosition;
    public Position nursePosBeforeHit;

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

    public List<Nurse> GetNursesInPosition(Position position)
    {
        List<Nurse> nursesInTargetPosition = new List<Nurse>();
        foreach (Nurse nurse in nurses)
        {
            if (nurse.position.column == position.column && nurse.position.row == position.row)
            {
                nursesInTargetPosition.Add(nurse);
            }
        }

        return nursesInTargetPosition;
    }
    
    public List<Nurse> GetNursesInPosition(List<Position> positions)
    {
        List<Nurse> nursesInTargetPositions = new List<Nurse>();
        foreach (Position position in positions)
        {
            nursesInTargetPositions.AddRange(GetNursesInPosition(position));
        }
        return nursesInTargetPositions;
    }

    public void TakeDamage(Nurse nurse)
    {
        nursePosBeforeHit = nurse.position;

        if (nurse.isDefusing)
        {
            MessageSystem.instance.Print("Mine defused at "+nursePosBeforeHit.Convert());
            GameManager.instance.bf.Demine(nursePosBeforeHit);
            nurse.isDefusing = false;
            MessageSystem.instance.Print("Defuse buff is lost");

            return;
        }
        
        if (nurse.toughness > 0)
        {
            nurse.toughness--;       
            GameManager.instance.NurseStepsOnMineWithToughness();
            GameManager.instance.bf.Demine(nursePosBeforeHit);
        }
        else
        {
            GameManager.instance.NurseStepsOnMine();
            nurse.MoveNurseBackToTrench();
            GameManager.instance.bf.Demine(nursePosBeforeHit);
            GameLoop.instance.DeselectTheCurrentNurse();

        }
        Debug.Log("E");
        Instantiate(explosion, explosePosition);
    }

}
