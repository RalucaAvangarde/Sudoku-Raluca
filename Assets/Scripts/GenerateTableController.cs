using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTableController
{
    private  GeneratorManager myGenerator;
    private  JsonUtils utils;

    public GenerateTableController()
    {
       
        utils = new JsonUtils();
    }

    public Square GenerateNewTable()
    {
        myGenerator = new GeneratorManager();
        return myGenerator.GenerateTable(15);
    }


}
