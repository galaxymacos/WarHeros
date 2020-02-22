using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse
{
    public Nurse()
    {
        // TODO position = GetNextNursePosition()
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
        // Demine(int x, int y)
    }
}

public class DetectMine : Skill
{
    public override void Cast()
    {
        // List<Position> minePositions = GameManager.BattleField.GetMinePositionAround(Position nursePosition)
    }
}

