using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class JsonUtils 
{
    private string fileName = "sudokuFile.json";
    private string filePath;
    public SudokuData DefaultElements;

   
    public JsonUtils()
    {// filePath = Path.Combine(Application.persistentDataPath, "SudokuFile.json");

        DefaultElements = new SudokuData();
        filePath = Application.persistentDataPath + "/" + fileName;
        Debug.Log(filePath);
        ReadData();
    }

    /// <summary>
    /// Save data in  file
    /// </summary>
    public void SaveData()
    {
        string contents = JsonUtility.ToJson(DefaultElements, true);
        File.WriteAllText(filePath, contents);
    }
    /// <summary>
    /// Read data from json file
    /// </summary>
    public void ReadData()
    {

        if (File.Exists(filePath))
        {
            string contents = File.ReadAllText(filePath);
            DefaultElements = JsonUtility.FromJson<SudokuData>(contents);

        }
        else
        {
            var temp = new SudokuData();
            temp.Tables = new List<SudokuList>();
            temp.Tables.Add(new SudokuList() { MyList = Enumerable.Repeat(0, 81).ToList() });
            DefaultElements = temp;
            SaveData();

        }
    }
}
