using System;
using UnityEngine;

public class UIMessager: MonoBehaviour
{
    public static UIMessager instance;

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

    public Action<Position> onInvalidNursePosition;
    
    public void SelectNurse(int index)
    {
        GameLoop.instance.currentNurseToMove = index;
    }

    public void MoveUp()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Up);
    }

    public void MoveDown()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Down);
    }
    
    public void MoveLeft()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Left);
    }

    public void MoveRight()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].Move(NurseMoveDirection.Right);
    }
    


}