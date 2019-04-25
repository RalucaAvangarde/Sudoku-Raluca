using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGeneratorManager : MonoBehaviour
{

    [SerializeField]
    private Text numbers;
    [SerializeField]
    private Transform container;
    private GenerateTableController generateTableController;

    private void Start()
    {
        generateTableController = new GenerateTableController();
    }

    public void DisplayGeneratedSolution()
    {
        ClearContainer();
        var table = generateTableController.GenerateNewTable();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                numbers.text = table.MySquare[i, j].ToString();
                if (table.MySquare[i, j] > 0)
                {
                    numbers.color = Color.red;
                    Instantiate(numbers, container);
                }
                else
                {
                    numbers.color = Color.black;
                    Instantiate(numbers, container);
                }


            }
        }

    }

    public void ClearContainer()
    {
        foreach (Transform item in container)
        {
            Destroy(item.gameObject);
        }
    }


}
