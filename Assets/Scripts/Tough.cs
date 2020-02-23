using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tough : Skill
    {
        const int skillPointMax = 2;
        private void Start()
        {
            skillName = "Solidité de la Fromagère";
            skillDescription = "Permet à l'infirmière de ne pas revenir à la tranchée lorsqu'elle déclenche une mine. 2 charges.";
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
            //TODO : implement a tough logic : doesn't come back to trench but the life lost isn't added to the "lives to save" pile
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

        public int RemainingSkillPoints()
        {
            return skillPoint;
        }
    }
}