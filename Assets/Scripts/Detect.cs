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
            skillDescription = "Permet à l'infirmière de détecter toutes les mines autour d'elle dans un rayon de 1 case. 1 charge.";
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
            GameManager.instance.bf.GetMineArroundPosition(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position);
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