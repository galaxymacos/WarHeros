﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Defuse : Skill
    {
        const int skillPointMax = 1;
        private void Start()
        {
            skillName = "Le fil bleu avec le fil rouge, et...";
            skillDescription = "Permet à l'infirmière de se déplacer sur une case. S'il y a une mine, celle-ci est désactivée. 1 charge.";
            isSkillAvailable = true;
            skillPoint = 1;
        }

        public override void Activate()
        {
            skillPoint--;
            if (skillPoint == 0)
            {
                isSkillAvailable = false;
            }
            GameManager.instance.bf.Demine(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position);
        }

        public override void Replenish()
        {
            if (skillPoint < skillPointMax && skillPoint >= 0)
            {
                skillPoint++;
            }
        }
    }
}