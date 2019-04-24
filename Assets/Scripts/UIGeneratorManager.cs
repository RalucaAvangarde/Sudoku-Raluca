using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGeneratorManager : MonoBehaviour
{
    private GeneratorManager myGenerator;
    private JsonUtils utils;
    [SerializeField]
    private Text numbers;
    [SerializeField]
    private Transform container;
    private Square gen;

    // Start is called before the first frame update
    void Start()
    {
       // utils = new JsonUtils();
        myGenerator = new GeneratorManager();
        DisplaySolution();
        
    }
    public void DisplaySolution()
    {
         gen = myGenerator.GenerateTable(15,null);
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                numbers.text = gen.MySquare[i,j].ToString();
                Instantiate(numbers, container);
               
            }
        }
        
    }

    public void SaveToJson()
    {
        var elements = new List<SudokuList>();
        gen.ConvertToList();
        utils.DefaultElements.Tables= elements;
        utils.SaveData();
    }
}
