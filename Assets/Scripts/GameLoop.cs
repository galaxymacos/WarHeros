using System.Collections.Generic;
using UnityEngine;

public class GameLoop: MonoBehaviour
{
    public static GameLoop instance;
    
    public List<Nurse> nurses;
    private int currentNurseToMove;

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

    public void NextTurn()
    {
        currentNurseToMove++;
        if (currentNurseToMove >= nurses.Count)
        {
            currentNurseToMove = 0;
        }
    }
    
}