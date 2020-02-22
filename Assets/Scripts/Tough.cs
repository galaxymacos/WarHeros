using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tough : Skill
    {
        const int skillPointMax = 3;
        private void Start()
        {
            skillName = "Solidité Fromagère";
            skillDescription = "Permet à l'infirmière de ne pas revenir à la tranchée lorsqu'elle déclenche une mine. 3 charges.";
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