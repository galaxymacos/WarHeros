using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierLocations : MonoBehaviour
{
    [SerializeField] GameObject[] frames;

    // Start is called before the first frame update
    void Start()
    {
        int[] arr = new int[] { 1,2,3,4,5,6,7,8};
        //get soldier position in a list from the battlefield - row and col
        for (int i = 0; i <arr.Length; i++)
        {
            frames[i].GetComponentInChildren<Text>().text = arr[i].ToString();//position row col;
        }
    }
}
