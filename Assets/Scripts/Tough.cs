using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tough : Skill
    {
        const int skillPointMax = 1;
        private void Start()
        {
            skillName = "Pistolet-Seringue";
            skillDescription = "Permet à l'infirmière de soigner un soldat situé dans une case adjacente.";
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
        }

        public override void Replenish()
        {
            if (skillPoint < skillPointMax && skillPoint >= 0)
            {
                skillPoint++;
            }
        }

        public bool IsSkillAvailable()
        {
            return isSkillAvailable;
        }
    }
}