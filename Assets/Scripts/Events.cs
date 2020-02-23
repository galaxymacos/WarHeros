using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    int[] events;
    int index = 0;

    public static Events instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        events = new int[32];

        for (int i = 0; i < events.Length; i++)
        {
            if (i < 4)
            {
                events[i] = 0;
            }

            else if (i < 12)
            {
                events[i] = 1;
            }

            else if (i < 20)
            {
                events[i] = 2;
            }

            else if (i < 28)
            {
                events[i] = 3;
            }

            else
            {
                events[i] = 4;
            }
        }

        for (int i = 0; i < events.Length - 1; i++)
        {
            int r = Random.Range(i, events.Length);
            //switch r and i
            int temp = events[i];
            events[i] = events[r];
            events[r] = temp;
        }
    }
    public void SelectRandomFunction()
    {
        if (index < events.Length - 1)
        {
            switch (events[index++])
            {
                case 0:
                    SpawnSoldier();
                    Debug.Log("Soldier");
                    MessageSystem.instance.Print("Event: A soldier has been spawned");
                    break;
                case 1:
                    SpawnMine();
                    Debug.Log("Mine");
                    MessageSystem.instance.Print("Event: A mine has been spawned");
                    break;
                case 2:
                    HailOfBullets();
                    Debug.Log("Bullets");
                    MessageSystem.instance.Print("Event: Hail of bullets");
                    break;
                case 3:
                default:
                    ArtilleryStrike();
                    Debug.Log("Artillery");
                    MessageSystem.instance.Print("Event: Artillery Strike");
                    break;
                case 4:
                    CarePackage();
                    Debug.Log("Care Package");
                    MessageSystem.instance.Print("Event: Care Package");
                    break;
            }
        }

        else
        {
            ArtilleryStrike();
        }

    }

    void ArtilleryStrike()
    {
        //get random position and detect mines around the position
        Position pos = GameManager.instance.bf.GetRandomPosInBoard(false);
        Debug.Log(pos.Convert());
        List<Position> area = new List<Position>();
        //tiles above
        area.Add(new Position(pos.column - 1, pos.row + 1));
        area.Add(new Position(pos.column, pos.row + 1));
        area.Add(new Position(pos.column + 1, pos.row + 1));
        //tiles below
        area.Add(new Position(pos.column - 1, pos.row - 1));
        area.Add(new Position(pos.column, pos.row - 1));
        area.Add(new Position(pos.column + 1, pos.row - 1));
        //tiles to the sides
        area.Add(new Position(pos.column - 1, pos.row));
        area.Add(pos);
        area.Add(new Position(pos.column + 1, pos.row));
        //destroy mines that were detected and injure soldiers and nurses in the area
        foreach (var a in area)
        {
            GameManager.instance.bf.Demine(a);

            if (GameManager.instance.bf.IsThereSoldier(a))
            {
                GameManager.instance.SoldierDie();
                GameManager.instance.bf.RemoveSoldier(a);
                Debug.Log("Kill Soldier");
            }

            if (NurseManager.instance.HasNurseInPosition(a))
            {
                //NurseManager.instance.TakeDamage(NurseManager.instance.nurses[GameLoop.instance.currentNurseToMove]);

                List<Nurse> nurses = NurseManager.instance.GetNursesInPosition(a);

                foreach (var n in nurses)
                {
                    //NurseManager.instance.TakeDamage(n);
                    GameManager.instance.DecreaseLive(1);
                    Debug.Log("Kill Nurse");
                }

            }
        }

        string message = "";

        for (int i = 0; i < 4; i++)
        {
            message += area[i].Convert();
            message += " , ";
        }
        MessageSystem.instance.Print(message);


        message = "";
        for (int j = 0; j < 5; j++)
        {
            message += area[j+4].Convert();
            message += " , ";
        }


        MessageSystem.instance.Print(message);

    }

    void HailOfBullets()
    {
        //get random position
        Position pos = GameManager.instance.bf.GetRandomPosInBoard(false);
        //select the column
        int col = pos.column;
        //get range (row)
        int range = 6;
        //injure soldiers and nurses in the area

        List<Position> area = new List<Position>();

        for (int i = 0; i < range; i++)
        {
            area.Add(new Position(col, GameManager.instance.bf.depth - i));
        }

        foreach (var a in area)
        {
            if (GameManager.instance.bf.IsThereSoldier(a))
            {
                GameManager.instance.SoldierDie();
                GameManager.instance.bf.RemoveSoldier(a);
            }

            if (NurseManager.instance.HasNurseInPosition(a))
            {
                //List<Nurse> nurses = NurseManager.instance.GetNursesInPosition(area);

                //foreach (var n in nurses)
                //{
                //    NurseManager.instance.TakeDamage(n);
                //}
                GameManager.instance.DecreaseLive(1);
            }
        }
    }

    void SpawnMine()
    {
        //spawn a mine in a random unoccupied space
        GameManager.instance.bf.SpawnEntities(1, BattleField.Entities.mine);
    }

    void SpawnSoldier()
    {
        //spawn a soldier in a random unoccupied space
        GameManager.instance.bf.SpawnEntities(1, BattleField.Entities.soldier);
    }

    void CarePackage()
    {
        for (int i = 0; i < NurseManager.instance.nurses.Count; i++)
        {
            if (NurseManager.instance.nurses[i].skill != null)
            {
                NurseManager.instance.nurses[i].skill.Replenish();
            }

            else
            {
                NurseManager.instance.nurses[i].toughness++;
            }
        }
    }
}
