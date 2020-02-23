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
            List<Position> positions = new List<Position>();
            // Position reversePosition =new Position(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column, NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row);
            positions = GameManager.instance.bf.GetMineArroundPosition(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position);
            if (positions.Count == 0)
            {
                print($"There is no mine near {Utility.NumberToChar(owner.position.row)}{owner.position.column}");
            }
            else
            {
                print("There are mines at the follow locations");
                foreach (Position position in positions)
                {
                    
                    print($"{Utility.NumberToChar(position.row)}{position.column}");
                }
            }
            
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