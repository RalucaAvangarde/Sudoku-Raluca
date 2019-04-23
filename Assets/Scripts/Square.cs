﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square 
{
    public int[,] MySquare { get; set; }
    public int BoardSize { get; set; }

   
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
    //Check if a number exists on a line
    //return true if find same number on the line else false
    public bool CheckLine(int coordX,int coordY, int nrVerified)
    {
        for (int i = 0; i < BoardSize; i++)
        {
            if (MySquare[i, coordY] == nrVerified && (i!=coordX))
            {  
                return false;
            }
            
        }
       
        return true;
    }
    // Check if a number exists on a column
   // return true if find same number on the line else false
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


    // Check if a number exists in a 3x3 square
    //return true if find same number in the 3x3 square else false
    public bool CheckIn3x3Square(int number, int coordX, int coordY)
    {
       
        int xStart = coordX / 3 * 3;

        int yStart = coordY / 3 * 3;


        for (int i = xStart; i < xStart + 3; i++)
        {
            for (int j = yStart; j < yStart + 3; j++)
            {
                if ((i != coordX) && (j != coordY) && (MySquare[i, j] == number))
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Check if a number can be placed: check column, check line, check insideSquare
    public bool CheckIfCanPlaceNumber(int coordX, int coordY, int number)
    {
        return CheckCol(number, coordX, coordY) && CheckLine(number, coordX, coordY)
                     && CheckIn3x3Square(number, coordX, coordY);
    }
    

    public void Table()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //Debug.Log(MySquare[i,j]);
            }
            
        }
        
    }
}
