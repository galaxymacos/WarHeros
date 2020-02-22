using System;
using System.Collections.Generic;

[Serializable]
public class InputData
{
    public InputData()
    {
        playerNum = 0;
        nurseTypes = new List<NurseType>();
    }
    
    public InputData(int playerNum, List<NurseType> nurseTypes)
    {
        this.playerNum = playerNum;
        this.nurseTypes = nurseTypes;
    }
    // Between 2 to 4
    
    public int playerNum;
    public List<NurseType> nurseTypes;

    
}