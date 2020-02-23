using System.Collections.Generic;
using UnityEngine;

public class BattleField
{
    //Random rnjesus;

    public enum Entities { mine, soldier };

    char[,] matrix;
    const char MINECHAR = 'm';
    const char SOLDIERCHAR = 's';
    public int width, depth, mineCount, soldierCount;

    public BattleField(int width, int depth, int mineCount, int soldierCount)
    {
        //rnjesus = new Random(265);
        this.width = width;
        this.depth = depth;
        this.mineCount = mineCount;
        this.soldierCount = soldierCount;
        matrix = new char[depth, width];
        FillField(mineCount);
        FillSoldiers(soldierCount);
        //SpawnEntities(soldierCount,Entities.soldier);
    }

    private void FillSoldiers(int soldierCount)
    {
        //number of mine to place in each row
        var countAtRow = new int[depth];
        var mineAtRow = new int[depth];
        //select wich row the mines go in
        for (int i = 0; i < soldierCount; i++)
        {
            //use for random
            int weight = 0;
            //chance for a row to get picked
            var weigthAtRow = new int[depth];
            //calculate chances for every row
            for (int r = 0; r < countAtRow.Length; r++)
            {
                //use the square of the row so there is more chance of higher row to get pick
                //the more mine there are in a row the less chance there will be one more mine in it

                for (int j = 0; j < width; j++)
                {
                    if (IsOccupied(new Position(i, j)))
                    {
                        mineAtRow[r]++;
                    }
                }


                weigthAtRow[r] = (int)(Mathf.Sqrt((r + 1)) * (width - mineAtRow[r]));
            }
            //add the weight of every row for the random
            //Console.WriteLine("countarow"+countAtRow.Length);
            foreach (var r in weigthAtRow)
            {
                //Console.WriteLine(r);
                weight += r;
            }
            ///random from 0 to weigth
            int rand = 0;
            rand = Random.Range(0, weight);
            //as soon as the cumulative weight goes over the random number you add a mine
            for (int j = 0, cumulativeWeight = 0; j < depth; j++)
            {
                cumulativeWeight += weigthAtRow[j];
                if (rand < cumulativeWeight)
                {
                    //if you place a mine you are done
                    countAtRow[j]++;
                    break;
                }
            }
        }
        //for each row
        for (int i = 0; i < depth; i++)
        {
            List<int> newList = new List<int>();
            //int[] newArray = new int[width - mineAtRow[i]];
            for (int j = 0; j < width; j++)
            {
                if (!IsOccupied(new Position(i, j)))
                {
                    newList.Add(j);
                }
            }
            int[] row = FisherYale(newList.ToArray());
            for (int j = 0; j < countAtRow[i]; j++)
            {
                matrix[i, row[j]] = SOLDIERCHAR;
            }
        }

    }

    public BattleField()
    {
        matrix = new char[6, 6];
        width = 6;
        depth = 6;
        matrix[0, 0] = MINECHAR;
        matrix[0, 1] = MINECHAR;
        matrix[5, 5] = SOLDIERCHAR;

        Debug.Log(CheckForMine(new Position(0, 0)));
        Debug.Log(CheckForMine(new Position(1, 0)));
        Debug.Log(IsThereSoldier(new Position(5, 5)));
        Debug.Log(IsThereSoldier(new Position(5, 3)));
        var Sols = GetSoldiers();
        foreach (var s in Sols)
        {
            Debug.Log(s.column + "," + s.row);
        }
        var mines = GetMineArroundPosition(new Position(1, 1));
        foreach (var m in mines)
        {
            Debug.Log(m.column + "," + m.row);
        }
        SpawnEntities(soldierCount, Entities.soldier);
    }

    private void FillField(int mineCount)
    {
        //number of mine to place in each row
        var countAtRow = new int[depth];
        //select wich row the mines go in
        for (int i = 0; i < mineCount; i++)
        {
            //use for random
            int weight = 0;
            //chance for a row to get picked
            var weigthAtRow = new int[depth];
            //calculate chances for every row
            for (int r = 0; r < countAtRow.Length; r++)
            {
                //use the square of the row so there is more chance of higher row to get pick
                //the more mine there are in a row the less chance there will be one more mine in it
                weigthAtRow[r] = (r + 1) * (width - countAtRow[r]);
            }
            //add the weight of every row for the random
            //Console.WriteLine("countarow"+countAtRow.Length);
            foreach (var r in weigthAtRow)
            {
                //Console.WriteLine(r);
                weight += r;
            }
            ///random from 0 to weigth
            int rand = 0;
            rand = Random.Range(0, weight);
            //as soon as the cumulative weight goes over the random number you add a mine
            for (int j = 0, cumulativeWeight = 0; j < depth; j++)
            {
                cumulativeWeight += weigthAtRow[j];
                if (rand < cumulativeWeight)
                {
                    //if you place a mine you are done
                    countAtRow[j]++;
                    break;
                }
            }
        }
        //for each row
        for (int i = 0; i < depth; i++)
        {
            int[] row = FisherYale(width);
            for (int j = 0; j < countAtRow[i]; j++)
            {
                matrix[i, row[j]] = MINECHAR;
            }
        }

    }

    private int[] FisherYale(int size)
    {
        var output = new int[size];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = i;
        }
        for (int i = 0; i < output.Length - 1; i++)
        {
            int r = Random.Range(i, output.Length);
            //switch r and i
            int temp = output[i];
            output[i] = output[r];
            output[r] = temp;
        }
        return output;
    }
    private int[] FisherYale(int[] toRdm)
    {
        var output = toRdm;
        for (int i = 0; i < output.Length - 1; i++)
        {
            int r = Random.Range(i, output.Length);
            //switch r and i
            int temp = output[i];
            output[i] = output[r];
            output[r] = temp;
        }
        return output;
    }

    public List<Position> GetMineArroundPosition(Position pos)
    {
        List<Position> output = new List<Position>();
        List<Position> toCheck = new List<Position>();
        //tiles above
        toCheck.Add(new Position(pos.column - 1, pos.row + 1));
        toCheck.Add(new Position(pos.column, pos.row + 1));
        toCheck.Add(new Position(pos.column + 1, pos.row + 1));
        //tiles below
        toCheck.Add(new Position(pos.column - 1, pos.row - 1));
        toCheck.Add(new Position(pos.column, pos.row - 1));
        toCheck.Add(new Position(pos.column + 1, pos.row - 1));
        //tiles to the sides
        toCheck.Add(new Position(pos.column - 1, pos.row));
        toCheck.Add(new Position(pos.column + 1, pos.row));

        foreach (var p in toCheck)
        {
            if (CheckForMine(p))
            {
                output.Add(p);
            }
        }
        return output;
    }

    public bool CheckForMine(Position pos)
    {
        //if out of board
        if (!IsPosInBoard(pos))
        {
            return false;
        }
        else if (matrix[pos.row, pos.column] == MINECHAR)
        {
            return true;
        }
        return false;
    }

    public int AdvencedCheckForMine(Position pos)
    {
        //if out of board
        if (!IsPosInBoard(pos))
        {
            return -1;
        }
        else if (matrix[pos.row, pos.column] == MINECHAR)
        {
            return 1;
        }
        return 0;
    }

    public bool IsPosInBoard(Position pos)
    {
        if (pos.row < 0 || pos.column < 0 || pos.row >= depth || pos.column >= width)
        {
            return false;
        }
        return true;
    }

    public bool Demine(Position pos)
    {
        if (IsPosInBoard(pos))
        {
            if (matrix[pos.row, pos.column] == MINECHAR)
            {
                matrix[pos.row, pos.column] = default;
                return true;
            }
        }
        return false;
    }

    public Position getTrenchPosition(int trenchIndex)
    {
        return new Position(column: -1, row: -1 * trenchIndex);
    }

    public bool IsNurseInTrench(Position pos)
    {
        return pos.column == -1;
    }

    public bool IsThereSoldier(Position pos)
    {
        if (IsPosInBoard(pos))
        {
            return matrix[pos.row, pos.column] == SOLDIERCHAR;
        }
        return false;
    }

    public void SpawnEntities(int amount, Entities type)
    {
        for (int i = 0; i < amount; i++)
        {
            while (!SpawnEntity(type)) ;
        }
    }

    private bool SpawnEntity(Entities type)
    {
        char ent = default;
        switch (type)
        {
            case Entities.mine:
                {
                    ent = MINECHAR;
                    break;
                }
            case Entities.soldier:
                {
                    ent = SOLDIERCHAR;
                    break;
                }
        }

        int rand = Random.Range(0, depth * width);
        Position randPos = new Position(row: rand / width, column: rand % width);
        if (IsOccupied(randPos))
        {
            return false;
        }
        else
        {
            matrix[rand / width, rand % width] = ent;
            return true;
        }
    }

    private bool IsOccupied(Position pos)
    {
        if (IsPosInBoard(pos))
        {
            if (matrix[pos.row, pos.column] == default)
            {
                return false;
            }
        }
        return true;
    }

    public List<Position> GetSoldiers()
    {
        List<Position> output = new List<Position>();
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Position check = new Position(i, j);
                if (IsThereSoldier(check))
                {
                    output.Add(check);
                }
            }
        }
        return output;
    }

    public void RemoveSoldier(Position pos)
    {
        if (IsPosInBoard(pos))
        {
            if (matrix[pos.row, pos.column] == SOLDIERCHAR)
            {
                matrix[pos.row, pos.column] = default;
            }
        }
    }

    public Position GetRandomPosInBoard(bool hasToBeVacant)
    {
        Position nPos;
        bool vacant = !hasToBeVacant;
        do
        {
            nPos = GetRdmPos();
            if (hasToBeVacant)
            {
                vacant = !IsOccupied(nPos);
            }
        }
        while (!vacant);
        return nPos;
    }

    private Position GetRdmPos()
    {
        return new Position(Random.Range(0, depth), Random.Range(0, width));
    }

    //public void PrintField()
    //{
    //    for(int i=0;i<depth;i++)
    //    {
    //        for(int j=0;j<width;j++)
    //        {
    //            if(matrix[i,j]==MINECHAR)
    //            {
    //                Console.Write("x ");
    //            }
    //            else
    //            {
    //                Console.Write(". ");
    //            }
    //        }
    //        Console.WriteLine();
    //    }
    //}

}