using System;
using System.Collections.Generic;
using System.Linq;


public class GeneratorManager
{
    public Square NewTable { get; set; }
    private List<int> LastRandom = new List<int>();
    public SudokuSolver SolveTable { get; set; }

    public GeneratorManager()
    {
        NewTable = new Square();
        SolveTable = new SudokuSolver();
    }

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
        }

        SolveTable.MyTable = new Square(baseTable, 9);

        if (SolveTable.IsSolvable() == true) //base table is solved
        {
            SolveTable.Solve();
            var solution = SolveTable.firstSolution;
            int[,] generatedTable = RemoveElements(solution, filledCells);
            NewTable = new Square(generatedTable, 9);
            return NewTable;
        }
        else //base is not solvable
        {
            return new Square(new int[9, 9], 9);
        }
    }
    
    private int[,] RemoveElements(int[,] solution, int filledCells)
    {
        //var count = filledCells;

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




