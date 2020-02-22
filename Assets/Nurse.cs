using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nurse: MonoBehaviour
{
    private void Awake()
    {
        
    }

    public Position position;
    public Skill skill;
    public int mobilityEachTurn;
    public int mobilityCounter = 0;
    
    
    public bool isPlaying => mobilityCounter > 0;
}

public class RedNurse: Nurse
{
    public RedNurse()
    {
        skill = new Defuse();
        mobilityCounter = 1;
    }
}

public class GreenNurse : Nurse
{
    public GreenNurse()
    {
        skill = new DetectMine();
        mobilityCounter = 1;
    }
}

public class Defuse: Skill{
    public override void Cast()
    {
        // GameManager.instance.Demine(Position defusePosition)
    }
}

public class DetectMine : Skill
{
    public override void Cast()
    {
        // TODO List<Position> minePositions = GameManager.instance.battleField.GetMinePositionAround(Position nursePosition)
    }
}

public class GameLoop: MonoBehaviour
{
    public static GameLoop instance;
    
    public List<Nurse> nurses;
    private int currentNurseToMove;
    
    
    
}

public enum GameState{
    Nurse1, Nurse2, Nurse3, Nurse4
}

