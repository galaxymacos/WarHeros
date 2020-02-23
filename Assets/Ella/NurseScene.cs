using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NurseScene : MonoBehaviour
{
    Nurse currentNurse;
    Text positionTxt;
    //Position position;
    [SerializeField] Image nurseImage;
    Sprite nursePoetry;
    [SerializeField] int nIndex;

    [Space]

    [SerializeField] Sprite nurseImage1;
    [SerializeField] Sprite nurseImage2;
    [SerializeField] Sprite nurseImage3;
    [SerializeField] Sprite nurseImage4;

    Animator animator;

    UIMessager uiMessager;
    // Start is called before the first frame update
    void Awake()
    {
        positionTxt = GameObject.Find("LocationTxt").GetComponent<Text>();
        uiMessager = GetComponent<UIMessager>();
        positionTxt.text = "A1";
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nurseImage.sprite = ChangePoetry();
        positionTxt.text = "A1";
        Debug.Log("Hello");
        Debug.Log(positionTxt.name);
    }

    public void SetIndex(int index)
    {
        nIndex = index;
        Debug.Log(index);
    }

    void SetCurrentIndex(int index)
    {
        Sprite image;
        switch (index)
        {
            case 0:
                animator.SetTrigger("Bridget");
                break;
            case 1:
                animator.SetTrigger("Grey");
                break;
            case 2:
                animator.SetTrigger("Purple");
                break;
            case 3:
                animator.SetTrigger("Green");
                break;
            default:
                animator.SetTrigger("None");
                break;

        }
    }

    Sprite ChangePoetry()
    {

        Sprite image;
        switch (GameLoop.instance.currentNurseToMove)
        {
            case 0:
                image = nurseImage1;
                break;
            case 1:
                image = nurseImage2;
                break;
            case 2:
                image = nurseImage3;
                break;
            default:
                image = nurseImage4;
                break;

        }
        return image;
    }
}
