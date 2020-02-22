using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [HideInInspector] public int playerNumber;
    [SerializeField] private NurseSelectionPanel nurseSelectionPanel;

    public InputData inputData;
    
    public static MainMenuManager instance;

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
        inputData = new InputData();
    }
    public void SetPlayer(int number)
    {
        playerNumber = number;
        inputData.playerNum = number;
        nurseSelectionPanel.gameObject.SetActive(true);
        nurseSelectionPanel.Setup();
    }

    public void PrintInputData()
    {
        for (int i = 0; i < inputData.nurseTypes.Count; i++)
        {
            print($"Player {i+1} chooses {inputData.nurseTypes[i]}");
        }
    }
}
