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
}
