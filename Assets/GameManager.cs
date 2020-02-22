﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BattleField bf;

    public int RegimenLives = 3;
    public int soldiersToSave = 3;
    
    
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        bf = new BattleField(12,12,20,8);
    }

    public void NurseStepsOnMine()
    {
        RegimenLives -= 1;
        soldiersToSave += 1;
    }

    public void CheckGameEndCondition()
    {
        if (RegimenLives <= 0)
        {
            print("You lose the game");
        }

        if (soldiersToSave <= 0)
        {
            print("You win the game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}