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
    
}
