using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolverController 
{
    private SudokuSolver solver;
    private JsonUtils utils;

    public SolverController()
    {
        solver = new SudokuSolver();
        utils = new JsonUtils();
    }

    public Square GetTableByID(int id)
    {
        return new Square().ConvertToMatrix(utils.DefaultElements.Tables[id].MyList);
    }

    public Square SolveTable(Square table)
    {
        solver.MyTable = table;
        solver.Solve();
        return new Square() { MySquare=solver.firstSolution };
    }

    public int GetTablesCount()
    {
        return utils.DefaultElements.Tables.Count;
    }

}
