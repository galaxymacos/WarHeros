using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Defuse : Skill
    {
        const int skillPointMax = 1;
        private void Start()
        {
            skillName = "Acuité visuelle";
            skillDescription = "Permet à l'infirmière de voir ";
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

        public override bool IsSkillAvailable()
        {
            return isSkillAvailable;
        }
    }
}