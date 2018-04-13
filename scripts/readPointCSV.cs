using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class readPointCSV : MonoBehaviour {
    public string filename;
    public Material material;
    Vector4[] positions;
    Vector4[] properties;

	// Use this for initialization
	void Start () {
        string filePath = Application.dataPath + "/CSV/";
        string RealFile = filePath + filename + ".csv";
        string fileData = File.ReadAllText(RealFile);
        string[] lines = fileData.Split("\n"[0]);
        positions = new Vector4[lines.Length-1];
        properties = new Vector4[lines.Length-1];
        string[] lineData;
        int i = 0;
        bool s = true;
        foreach (string element in lines)
        {
            if (s)
            {
                s = false;
                continue;//skip the first line
            }
            Debug.Log(element);
            lineData = (element.Trim()).Split(","[0]);
            Debug.Log(lineData[0]);
            if (lineData[0].ToString() != "")
            {
                positions[i].Set(float.Parse(lineData[0]), float.Parse(lineData[1]), float.Parse(lineData[2]), 0);
                properties[i++].Set(float.Parse(lineData[3]), float.Parse(lineData[4]), float.Parse(lineData[5]), 0);
            }
            
        }
        int count = positions.Length;
        material.SetInt("_Points_Length", count);
        material.SetVectorArray("_Points", positions);
        material.SetVectorArray("_Properties", properties);



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
