using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
   
    public Text MyText;
    public Text MyText1;
    public Transform parentText;
    public Transform parentText1;
    public List<int> lst = new List<int>();
    // Start is called before the first frame update
    void Start()

    {
      
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //Debug.Log(GetBoard()[i, j] + " ");
               // MyText.text = GetBoard()[i, j].ToString();
                //Instantiate(MyText, parentText);
            }
            
        }

        Debug.Log("----------------------------------------");
        var solver = new SudokuSolver(GetBoard());
        if (solver.Solve())
        {
            var sol = solver.firstSolution;
            foreach (var item in sol)
            {
                Debug.Log(item);
                //MyText1.text = item.ToString();
                //Instantiate(MyText1, parentText1);
            }
        }

        Debug.Log("----------------------------------------");
         var y = new GeneratorManager().GenerateTable(15, GetBoard());

         for (int i = 0; i < 9; i++)
         {
             for (int j = 0; j < 9; j++)
             {
                Debug.Log(y.MySquare[i, j] + " ");
              // MyText1.text = y.MySquare[i, j].ToString();
              // Instantiate(MyText, parentText1);
            }

         }
      
       //solve generated board
        solver = new SudokuSolver(y);
         solver.Solve();
        var sol1 = solver.firstSolution;
         for (int i = 0; i < 9; i++)
         {
             for (int j = 0; j < 9; j++)
             {
                 //Debug.Log(sol1[i, j] + " ");
                //MyText.text = y.MySquare[i, j].ToString();
               // Instantiate(MyText, parentText);
            }

         }
    }

    private static int[,] GetBoard()
    {
        return new int[9, 9]
        {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
    }


   
}
