using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DistanceHeal : Skill
    {
        const int skillPointMax = 1;
        [SerializeField] DistanceHealPanel distanceHealPanel;

        private void Start()
        {
            skillName = "Pistolet-Seringue";
            skillDescription = "Permet à l'infirmière de soigner un soldat situé dans une case adjacente. 1 charge.";
            isSkillAvailable = true;
            skillPoint = 1;
        }

        public override void Activate()
        {
            print("minus a skill point");
            skillPoint--;
            if (skillPoint == 0)
            {
                print("no more skill points");
                isSkillAvailable = false;
            }
            print("try to activate distance heal panel");
            distanceHealPanel.ActivatePanel();
        }

        public override void Replenish()
        {
            print("In the replenish method");

            if (skillPoint < skillPointMax && skillPoint >= 0)
            {
                print("has been replenished");
                skillPoint++;
                isSkillAvailable = true;
            }
        }
    }
}