using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image nursePortray;

    public Text mobilityPointText;

    public Text locationText;

    public Text soldiersAliveText;

    public Text RegementLeftText;

    public GameObject currentNursePanel;
    public GameObject leftButton;
    public GameObject topButton;
    public GameObject rightButton;
    public GameObject downButton;
    // public GameObject skillButton;

    public static UiManager instance;




    public Action<Position> onLocationChanged;

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

        onLocationChanged += UpdateLocationText;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameLoop.instance.currentNurseToMove != -1)
        {
            //nursePortray.sprite = NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].sprite;
            mobilityPointText.text = NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].mobilityCounter
                .ToString();

        }
        else
        {
            mobilityPointText.text = "0";
        }


        soldiersAliveText.text = GameManager.instance.soldiersToSave.ToString();
        RegementLeftText.text = GameManager.instance.RegimenLives.ToString();


        SetVisibilityToUI();

    }

    public void SetVisibilityToUI()
    {
        if (GameLoop.instance.currentNurseToMove == -1)
        {
            currentNursePanel.SetActive(false);
            // skillButton.SetActive(false);
            
        }
        else
        {
            currentNursePanel.SetActive(true);

            // if (NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].skill.IsSkillAvailable())
            // {
            //     skillButton.SetActive(true);
            // }
            // else
            // {
            //     skillButton.SetActive(false);
            // }
        }

        if (GameLoop.instance.currentNurseToMove != -1)
        {
            if (GameManager.instance.bf.IsPosInBoard(new Position(
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row,
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column - 1)))
            {
                leftButton.SetActive(true);
            }
            else
            {
                leftButton.SetActive(false);
            }

            if (GameManager.instance.bf.IsPosInBoard(new Position(
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row + 1,
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column)))
            {
                topButton.SetActive(true);
            }
            else
            {
                topButton.SetActive(false);
            }

            if (GameManager.instance.bf.IsPosInBoard(new Position(
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row,
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column + 1)))
            {
                rightButton.SetActive(true);
            }
            else
            {
                rightButton.SetActive(false);
            }

            if (GameManager.instance.bf.IsPosInBoard(new Position(
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row - 1,
                NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column)))
            {
                downButton.SetActive(true);
            }
            else
            {
                downButton.SetActive(false);
            }
        }

    }

    public void UpdateLocationText(Position position)
    {
        locationText.text = Utility.NumberToChar(position.row) + " " + position.column;
    }


     
}