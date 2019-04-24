using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
   
    public Text MyText;
    public Transform parentText;
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
                //Debug.Log(item);
                //MyText.text = item.ToString();
                //Instantiate(MyText, parentText);
            }
        }

        Debug.Log("----------------------------------------");
         var y = new GeneratorManager().GenerateTable(15, GetBoard());

         for (int i = 0; i < 9; i++)
         {
             for (int j = 0; j < 9; j++)
             {
                //Debug.Log(y.MySquare[i, j] + " ");
                MyText.text = y.MySquare[i, j].ToString();
                Instantiate(MyText, parentText);
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
