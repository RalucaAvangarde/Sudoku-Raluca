using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SudokuData 
{
    public List<SudokuList> Tables;
}

[Serializable]
public class SudokuList
{
    public List<int> MyList;
}
