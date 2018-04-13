using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CsvReadWrite : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public bool overwriteExistingFile = false;

    // Use this for initialization
    void Start()
    {
        Save();
    }

    void Save()
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[6];
        rowDataTemp[0] = "positionX";
        rowDataTemp[1] = "positionY";
        rowDataTemp[2] = "positionZ";
        rowDataTemp[3] = "propertyX";
        rowDataTemp[4] = "propertyY";
        rowDataTemp[5] = "propertyZ";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for (int i = 0; i < 500; i++)
        {
            rowDataTemp = new string[6];
            rowDataTemp[0] = "positionX";
            rowDataTemp[1] = "positionY";
            rowDataTemp[2] = "positionZ";
            rowDataTemp[3] = "propertyX";
            rowDataTemp[4] = "propertyY";
            rowDataTemp[5] = "propertyZ";
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
        String fileName = Application.dataPath + "/CSV/Saved_data";
        string testFileName = fileName + ".csv";
        if (!overwriteExistingFile)
        {
            int counter = 1;
            while (File.Exists(testFileName))
            {
                testFileName = fileName + "_" + (counter++) + ".csv"; // e.g., "results_12.csv"
            }
        }
        fileName = testFileName;

        Debug.Log("Writing data to " + fileName);
        #if UNITY_EDITOR
            return fileName;
        #elif UNITY_ANDROID
            return fileName;
        #elif UNITY_IPHONE
            return fileName;
        #else
            return fileName;
        #endif
    }
}