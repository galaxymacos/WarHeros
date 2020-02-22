using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    //string skillName;
    //string skillDescription;
    //private int skillPoint;
    //private const int skillPointMax = 2;

    public Skill(string skillName, string skillDescription, int skillPoint)
    {
        //this.skillName = skillName;
        //this.skillDescription = skillDescription;
        //this.skillPoint = skillPoint;
    }

    public virtual void Activate()
    {
        //skillPoint--;
    }

    public virtual void Replenish()
    {
        //if (skillPoint < skillPointMax)
        //{
        //    skillPoint++;
        //}
    }

    //public virtual string[] ReadSkill()
    //{
    //    //string[] result = new string[2];
    //    //result[0] = skillName;
    //    //result[1] = skillDescription;
    //    //return result;
    //}
}
