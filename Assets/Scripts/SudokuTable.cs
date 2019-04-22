//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//    public class SudokuTable
//    {
//        public List<Square> MyTable { get; set; }

//        public SudokuTable()
//        {
//            MyTable = new List<Square>();
//        }

//        public bool CheckTableLine(int rowIndex, int squareIndex, int nr)
//        {
//            int contor = 0;
//            for (int i = rowIndex; i < rowIndex + 3; i++)
//            {
//                if (MyTable[i].CheckLine(squareIndex, nr) == true)
//                {
//                    contor++;
//                }

//                if (contor == 0)
//                {
//                    return false;   // nr doesn`t exist on line
//                }
//            }

//            return true;
//        }
//        public bool CheckTableColumn(int colIndex, int squareIndex, int nr)
//        {
//            int contor = 0;
//            for (int i = colIndex; i < 9; i += 3)
//            {
//                if (MyTable[i].CheckCol(squareIndex, nr) == true)
//                {
//                    contor++;
//                }

//                if (contor == 0)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }
//    }

