using System;
using System.Collections.Generic;
using System.Linq;


public class GeneratorManager
{
    public Square NewTable { get; set; }
    public SudokuSolver SolveTable { get; set; }
    private JsonUtils utils;


    public GeneratorManager()
    {
        NewTable = new Square();
        SolveTable = new SudokuSolver();
        utils = new JsonUtils();
    }
    /// <summary>
    /// Count all not null numbers from table 
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    private int GetNumberOfNotNullElements(int[,] table)
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (table[i, j] != 0)
                {
                    count++;
                }
            }
        }
        return count;
    }

   
    public Square GenerateTable(int filledCells, int[,] baseTable = null)
    {
        if (baseTable == null)
        {
            baseTable = new int[9, 9];
            baseTable[0, UnityEngine.Random.Range(0, 9)] = UnityEngine.Random.Range(0,9);
            
        }

        SolveTable.MyTable = new Square(baseTable, 9);

        if (SolveTable.IsSolvable() == true) //base table is solved
        {
            SolveTable.Solve();
            var solution = SolveTable.firstSolution;
            int[,] generatedTable = RemoveElements(solution, filledCells);
            NewTable = new Square(generatedTable, 9);
            utils.DefaultElements.Tables.Add(new SudokuList() { MyList = NewTable.ConvertToList() });
            utils.SaveData();
            return NewTable;
        }
        else //base is not solvable
        {
            return new Square(new int[9, 9], 9);
        }
    }
    /// <summary>
    /// Remove random numbers from table
    /// </summary>
    /// <param name="solution"></param>
    /// <param name="filledCells"></param>
    /// <returns></returns>
    private int[,] RemoveElements(int[,] solution, int filledCells)
    {
   
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var rand = UnityEngine.Random.Range(0, 2);
                if (rand == 1)
                {
                    solution[i, j] = 0;

                    if (GetNumberOfNotNullElements(solution) <= filledCells)
                    {
                        return solution;
                    }

                }
            }
        }
        if (GetNumberOfNotNullElements(solution) > filledCells)
        {
            return RemoveElements(solution, filledCells);
        }
        return solution;
    }
}




