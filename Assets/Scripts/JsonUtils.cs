using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonUtils : MonoBehaviour
{
    private string fileName = "sudokuFile.json";
    private string filePath;
    public SudokuData DefaultElements;

    public void Awake()
    {// filePath = Path.Combine(Application.persistentDataPath, "SudokuFile.json");

        DefaultElements = new SudokuData();
        filePath = Application.persistentDataPath + "/" + fileName;
        Debug.Log(filePath + "Json path");
        ReadData();
    }

    /// <summary>
    /// Save data in products file
    /// </summary>
    public void SaveData()
    {
        string contents = JsonUtility.ToJson(DefaultElements, true);
        File.WriteAllText(filePath, contents);
    }

    public void ReadData()
    {

        if (File.Exists(filePath))
        {
            string contents = File.ReadAllText(filePath);
            DefaultElements = JsonUtility.FromJson<SudokuData>(contents);

        }
        else
        {
            Debug.Log("Unable to read default input file");

        }
    }
}
