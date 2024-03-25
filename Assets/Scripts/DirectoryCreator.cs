using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DirectoryCreator : MonoBehaviour
{

    public string directoryPath = Directory.GetCurrentDirectory() + "/logs/Files/XLM-JSON-Files";
    // Start is called before the first frame update
    void Start()
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
            Debug.Log("Directory Created at: " + directoryPath);
        }
        else 
        {
            Debug.LogWarning("Directory already exists at: " + directoryPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
