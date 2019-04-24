using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISolverController : MonoBehaviour
{
    private SolverController mySolver;
    [SerializeField]
    private Text myText;
    [SerializeField]
    private Transform tableParent;
    [SerializeField]
    private Transform solverParent;
    [SerializeField]
    private Dropdown dropDownSelectTable;

    private Square tableFromJson;
    void Start()
    {
        mySolver = new SolverController();
        FillDropDownOptions();
    }

    public void FillDropDownOptions()
    {
        var optionList = Enumerable.Range(0, mySolver.GetTablesCount())
                                    .Select(x => x.ToString())
                                    .ToList();

        dropDownSelectTable.ClearOptions();
        dropDownSelectTable.AddOptions(optionList);
    }

    public void GetTable()
    {
        tableFromJson = mySolver.GetTableByID(dropDownSelectTable.value);
    }

    public void DisplayTable()
    {
        DisplayTable(tableFromJson, tableParent);
    }

    public void DisplaySolution()
    {
        DisplayTable(mySolver.SolveTable(tableFromJson), solverParent);
    }

    
    private void DisplayTable(Square table, Transform container)
    {
        ClearContainer(container);

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                myText.text = table.MySquare[i, j].ToString();
                if (table.MySquare[i, j] > 0)
                {
                    myText.color = Color.red;
                    Instantiate(myText, container);
                }
                else
                {
                    myText.color = Color.black;
                    Instantiate(myText, container);
                }


            }
        }

    }

    public void ClearContainer(Transform container)
    {
        foreach (Transform item in container)
        {
            Destroy(item.gameObject);
        }
    }
}
