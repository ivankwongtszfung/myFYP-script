// Alan Zucconi
// www.alanzucconi.com
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
public class Heatmap : MonoBehaviour
{
     Vector4[] positions;
     Vector4[] properties;
    private List<string[]> rowData = new List<string[]>();
    public Material material;
    public bool overwriteExistingFile = false;
    string x;
    Vector3 vec;
    Vector3 prev;
    int c = 0;
    int pcount = 0;
    static int xCount=0;
    static int yCount=0;

    int count = 500;
    void Start()
    {
        positions = new Vector4[count];
        properties = new Vector4[count];
        prev = Vector3.zero;
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new Vector4(UnityEngine.Random.Range(-0.4f, +0.4f), UnityEngine.Random.Range(-0.4f, +0.4f), 1, 0);
            properties[i] = new Vector4(UnityEngine.Random.Range(0.8f, 1.0f), UnityEngine.Random.Range(0.3f, 0.5f), 0, 0);
        }
        //set tex point to zero
        //   x:0
        //y:0

    }
   
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
            //hit.transform.GetComponent<timerScript>().startCounting();
            if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
            {
                // Debug.Log(hit.point);
                transform.position = hit.point;
                x = hit.transform.tag;
                vec = hit.point;

            }
        }

        if (x == "Player")
        {
            if (Vector3.Distance(prev, vec) > 0.9 || prev == Vector3.zero)
            {

                prev = vec;
                if (c < count)
                {
                    pcount = c;
                    positions[c++] = new Vector4(vec.x, vec.y, vec.z, 0);
                    Debug.Log(c + ":" + count);
                }
                else
                {
                    if (c >= count)
                    {
                        Debug.Log("this is end");
                        c = 0;
                    }

                }
            }
            else
            {
                if (properties[pcount].y < 1.0)
                    properties[pcount] += new Vector4(0, 0.005f, 0, 0);
            }
        }
        
        for (int i = 0; i < positions.Length; i++)
            positions[i] += new Vector4(UnityEngine.Random.Range(-0.1f, +0.1f), UnityEngine.Random.Range(-0.1f, +0.1f), 0, 0) * Time.deltaTime;

        material.SetInt("_Points_Length", count);
        material.SetVectorArray("_Points", positions);
        material.SetVectorArray("_Properties", properties);
    }

    private void OnApplicationQuit()
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
        for (int i = 0; i < c; i++)
        {
            rowDataTemp = new string[6];
            rowDataTemp[0] = positions[i].x.ToString();
            rowDataTemp[1] = positions[i].y.ToString();
            rowDataTemp[2] = positions[i].z.ToString();
            rowDataTemp[3] = properties[i].x.ToString();
            rowDataTemp[4] = properties[i].y.ToString();
            rowDataTemp[5] = properties[i].z.ToString();
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < c; i++)
        {
            output[i] = rowData[i];
        }

        int length = c;
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++) {
            sb.AppendLine(string.Join(delimiter, output[index]));
        }



        string filePath = getPath();

        StreamWriter outStream = File.CreateText(filePath);
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