using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierLocations : MonoBehaviour
{
    [SerializeField] GameObject[] frames;
    List<Position> soldierPositions;

    public List<Position> SoldierPositions { get => soldierPositions; set => soldierPositions = value; }

    // Start is called before the first frame update
    void Start()
    {
        soldierPositions = GameManager.instance.bf.GetSoldiers();

        for (int i = 0; i <soldierPositions.Count; i++)
        {
            Debug.Log(soldierPositions[i].row + " " + soldierPositions[i].column);
            frames[i].GetComponentInChildren<Text>().text = soldierPositions[i].Convert();
        }
    }
}
