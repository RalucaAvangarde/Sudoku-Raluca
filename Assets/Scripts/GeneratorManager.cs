using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


    public class GeneratorManager
    {
        public Square NewTable { get; set; }
        private List<int> LastRandom = new List<int>();
        public SudokuSolver MySudokuTable { get; set; }

    public GeneratorManager()
        {
            NewTable = new Square();
            MySudokuTable = new SudokuSolver(NewTable);
        }

        private int generateRandomNumber(int min, int max)
        {
            int number = 0;
            var rand = new System.Random();
            bool _continue = true;
            while (_continue == true)
            {
                number = rand.Next(min, max);
                if (!LastRandom.Skip(LastRandom.Count - 3).Take(3).Contains(number))
                {
                    LastRandom.Add(number);
                    return number;
                }
            }
            return number;
        }

        private int GetNumberOfNotNullElements()
        {
            int count = 0;
            for (int i = 0; i < NewTable.BoardSize; i++)
            {
                for (int j = 0; j < NewTable.BoardSize; j++)
                {
                    if (NewTable.MySquare[i, j] != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    //generate table with nr of elements
        public Square GenerateTable(int filledCells)
        {
            var goodSolution = false;

            while (goodSolution != true)
            {
                NewTable.MySquare = new int[9, 9];
                int index = 0;
                while (index < filledCells)
                {
                    NewTable.MySquare[generateRandomNumber(1, 8), generateRandomNumber(1, 8)] = generateRandomNumber(1, 8);
                   
                    index = GetNumberOfNotNullElements();
                }
                if (MySudokuTable.IsSolvable())
                {
                    goodSolution = true;
                    return NewTable;
                }
            }
            return NewTable;

        }
    }




