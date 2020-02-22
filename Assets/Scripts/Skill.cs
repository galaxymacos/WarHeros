﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected string skillName;
    protected string skillDescription;
    protected private bool isSkillAvailable;
    protected private int skillPoint;

    public virtual void Activate()
    {
    }

    public virtual void Replenish()
    {
    }

    protected virtual string[] ReadSkill()
    {
        string[] result = new string[2];
        result[0] = skillName;
        result[1] = skillDescription;
        return result;
    }
}
