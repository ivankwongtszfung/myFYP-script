using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DataClass
{
    private static Dictionary<int, float> furniture;
    private static DateTime startUnity, endUnity;

    public void SetFurnitureTime(int id,float time)
    {
        //set the gaze time of furniture
        if (furniture.ContainsKey(id))
        {
            furniture[id] = time;
        }
        else
        {
            furniture.Add(id, time);
        }
        
    }

    public DateTime StartUnity
    {
        get
        {
            return startUnity;
        }
        set
        {
            startUnity = value;
        }
        
    }

    public DateTime EndUnity
    {
        get
        {
            return endUnity;
        }
        set
        {
            startUnity = value;
        }
    }







}
