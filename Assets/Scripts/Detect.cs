using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Detect : Skill
    {
        const int skillPointMax = 1;
        private void Start()
        {
            skillName = "Acuité visuelle";
            skillDescription = "Permet à l'infirmière de détecter les mines autour d'elle .";
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