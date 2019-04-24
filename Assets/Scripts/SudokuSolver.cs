using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuSolver 
{
    private int solutionCount;
    public int[,] firstSolution;

    public Square MyTable { get; set; }

    public Square Solution { get; set; }


    public SudokuSolver(int[,] sudokuBoard)
    {
        MyTable = new Square(sudokuBoard, 9);
    }

    public SudokuSolver(Square sudokuBoard)
    {
        MyTable = sudokuBoard;
    }

    public SudokuSolver()
    {
    }


    // place a number at x,y coord in sudoku table
    //bool if number was placed succesfully else false
    private bool SolveCell(int coordX, int coordY)
    {
       
        for (int i = 1; i <= 9; i++)
        {
            if (MyTable.CheckIfCanPlaceNumber(i, coordX, coordY))
            {
                MyTable.MySquare[coordX, coordY] = i;
                if (SolveTable())
                {
                    if (solutionCount == 0)
                    {
                        CopyBoard(MyTable.MySquare);
                    }

                    solutionCount++;

                    if (solutionCount >= 2)
                    {
                        return true;
                    }
                }
            }
        }

        //failed to find sol
        MyTable.MySquare[coordX, coordY] = 0; //modify value back to 0 if solution was not found
        return false;
    }

    private void CopyBoard(int[,] boardData)
    {
        firstSolution = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                firstSolution[i, j] = boardData[i, j];
            }
        }
    }

    private bool SolveTable()
    {
        for (int i = 0; i < MyTable.BoardSize; i++)
        {
            for (int j = 0; j < MyTable.BoardSize; j++)
            {
                if (MyTable.MySquare[i, j] == 0)
                {
                    return SolveCell(i, j);
                }
            }
        }

        return true;
    }

    public bool IsSolvable()
    {
        //check if there are no duplicates on tables row or coll or square
        for (int i = 0; i < MyTable.BoardSize; i++)
        {
            for (int j = 0; j < MyTable.BoardSize; j++)
            {
                if (MyTable.MySquare[i, j] > 0)
                {
                    if (MyTable.CheckIfCanPlaceNumber(MyTable.MySquare[i, j], i, j) == false)
                    {
                        // something is inconstent with this cell
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public bool Solve()
    {
        if (IsSolvable())
        {
            SolveTable();

            return solutionCount > 0;
        }
        return false;
    }
}

