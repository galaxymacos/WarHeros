using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BattleField bf;

    [SerializeField] public int RegimenLives = 3;
    [SerializeField] public int soldiersToSave = 3;
    
    
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        bf = new BattleField(12,12,20,8);
    }


    public void NurseStepsOnMine()
    {
        RegimenLives -= 1;
        soldiersToSave += 1;
        CheckGameEndCondition();

    }

    public void GainPointForHealingSoldiers()
    {
        soldiersToSave -= 1;
        CheckGameEndCondition();
    }

    public void NurseStepsOnMineWithToughness()
    {
        RegimenLives -= 1;
        CheckGameEndCondition();

    }

    public void SoldierDie()
    {
        RegimenLives -= 1;
        CheckGameEndCondition();
    }

    public void NurseDie()
    {
        NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].MoveNurseBackToTrench();
        RegimenLives -= 1;
        // soldiersToSave += 1;    TODO Don't increase the regiment when stepping on the mine to decrease the diffculty
        CheckGameEndCondition();
    }

    public void DecreaseLive(int lifeToDecrease)
    {
        RegimenLives -= lifeToDecrease;
        CheckGameEndCondition();
    }
    
    public void CheckGameEndCondition()
    {
        if (RegimenLives <= 0)
        {
            print("You lose the game");
            SceneManager.LoadScene(3);
        }

        if (soldiersToSave <= 0)
        {
            print("You win the game");
            SceneManager.LoadScene(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
