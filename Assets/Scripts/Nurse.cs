using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    private void Awake()
    {
        // TODO position = GameManager.instance.GetTrenchPosition(0);
    }

    // adjustable
    public Sprite sprite;
    
    // 
    public Position position;
    public Skill skill;
    public int mobilityEachTurn;
    public int mobilityCounter = 0;
    public bool canMove => mobilityCounter > 0;


    public void Heal()
    {
        
    }
    
    
}



public class GameLoop: MonoBehaviour
{
    public static GameLoop instance;
    
    public List<Nurse> nurses;
    private int currentNurseToMove;

    public void NextTurn()
    {
        currentNurseToMove++;
        if (currentNurseToMove >= nurses.Count)
        {
            currentNurseToMove = 0;
        }
    }
    
}

public enum GameState{
    Nurse1, Nurse2, Nurse3, Nurse4
}

