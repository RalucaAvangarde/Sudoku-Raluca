using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolverController 
{
    private SudokuSolver solver;

    public SolverController()
    {
        solver = new SudokuSolver();
        JsonUtils.ReadData();
        
    }

    public Square GetTableByID(int id)
    {
        return new Square().ConvertToMatrix(JsonUtils.DefaultElements.Tables[id].MyList);
    }

    public Square SolveTable(Square table)
    {
        solver.MyTable = table;
        solver.Solve();
        return new Square() { MySquare=solver.firstSolution };
    }

    public int GetTablesCount()
    {
        return JsonUtils.DefaultElements.Tables.Count;
    }

}
