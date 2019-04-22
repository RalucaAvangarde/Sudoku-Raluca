using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int[,] MySquare { get; set; }
    public int BoardSize { get; set; }

    public void Start()
    {
       // Table();
    }
    public Square()
    {
        BoardSize = 9;
        MySquare = new int[BoardSize, BoardSize] ;
    }

    public Square(int[,] mySquare, int boardSize)
    {
        BoardSize = boardSize;
        MySquare = new int[boardSize, boardSize];

        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                MySquare[i, j] = mySquare[i, j]; 
            }

        }
    }

    public bool CheckLine(int coordX,int coordY, int nrVerified)
    {
        for (int i = 0; i < BoardSize; i++)
        {
            if (MySquare[i, coordY] == nrVerified && i!=coordX)
            {  
                return false;
            }
        }
        Debug.Log("");
        return true;
    }

    public bool CheckCol(int coordX, int coordY, int nrVerified)
    {
        for (int i = 0; i < BoardSize; i++)
        {
            if (MySquare[coordX, i] == nrVerified && i != coordY)
            { 
                return false;
            }
        }

        return true;
    }

   

    public void Table()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Debug.Log(MySquare[i,j]);
            }
            
        }
        
    }
}
