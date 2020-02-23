using System.Collections;
using System.Collections.Generic;
using System.Text;
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
            print("activate the detect skill");
            skillPoint--;
            if (skillPoint == 0)
            {
                isSkillAvailable = false;
            }
            List<Position> positions = new List<Position>();
            Position reversePosition =new Position(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.column, NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove].position.row);
            
            positions = GameManager.instance.bf.GetMineArroundPosition(reversePosition);
            if (positions.Count == 0)
            {
                MessageSystem.instance.Print($"No mine near {owner.position.Convert()}");
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Mine found:");
                foreach (Position position in positions)
                {
                    builder.Append($"{position.Convert()} ");
                }
                MessageSystem.instance.Print(builder.ToString());

            }
            
            UiManager.instance.mineDetectionPanel.SetActive(true);
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