
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class timerScript : MonoBehaviour
{
    
    
    public bool CursorTriggered = false;

    public int pid = 1;
    DateTime ttff;
    float timespent;
    int visited;// 1 or 0
    string time_spent;//total time spent
    int fixation;
    int revisitor;//increment to infinity
    GazeData.GazeObject myGaze;
    // Use this for initialization
    void Start()
    {
        timespent = 0;
        visited = 0;
        timespent = 0;
        fixation = 0;
        revisitor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //adding up the deltatime
        if (CursorTriggered)
        {
            //update product cs     
            timespent += Time.deltaTime;

        }

    }
    public void StartTimer()
    {
        CursorTriggered = true;
        ttff = DateTime.Now;
        visited++;
        fixation++;
        revisitor = 1;
        
    }

    public void StopTimer()
    {
        CursorTriggered = false;
        //set the GazeObject
        GazeData.setGazeById(pid, visited, ttff.ToString(), timespent, fixation, revisitor);
        timespent = 0;

    }
 

}


