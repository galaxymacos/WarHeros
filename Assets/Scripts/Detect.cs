﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Detect : Skill
    {
        string skillName;
        string skillDescription;
        private int skillPoint;
        private bool isSkillAvailable;
        private const int skillPointMax = 1;

        public Detect(string skillName, string skillDescription, int skillPoint) : base(skillName, skillDescription, skillPoint)
        {
            this.skillName = skillName;
            this.skillDescription = skillDescription;
            this.skillPoint = skillPoint;
            isSkillAvailable = true;
        }

        public override void Activate()
        {
            if (isSkillAvailable)
            {
                skillPoint--;
            }
            if (skillPoint == 0)
            {
                isSkillAvailable = false;
            }
        }

        public override void Replenish()
        {
            if (skillPoint < skillPointMax && skillPoint >= 0)
            {
                skillPoint++;
            }
        }

        public string[] ReadSkill()
        {
            string[] result = new string[2];
            result[0] = skillName;
            result[1] = skillDescription;
            return result;
        }

        public bool IsSkillAvailable()
        {
            return isSkillAvailable;
        }
    }
}