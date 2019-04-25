using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class JsonUtils 
{
    private static string fileName = "Sudoku.json";
    private static string filePath;
    public static SudokuData DefaultElements = new SudokuData();


    /// <summary>
    /// Save data in  file
    /// </summary>
    public static void SaveData()
    {
        string contents = JsonUtility.ToJson(DefaultElements, true);
        filePath = Application.persistentDataPath + "/" + fileName;
        File.WriteAllText(filePath, contents);
    }
    /// <summary>
    /// Read data from json file
    /// </summary>
    public static void ReadData()
    {
        filePath = Application.persistentDataPath + "/" + fileName;
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
