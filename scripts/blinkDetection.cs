using UnityEngine;
using UnityEditor;
using Fove.Managed;
using System;
using FoveGCD = UnityEngine.FoveInterfaceBase.GazeConvergenceData;

public class blinkDetection : MonoBehaviour
{ 
    EFVR_Eye myEyeStruct;
    string prev = "";
    FoveGCD prevgcd;
    FoveGCD gcd;
    RaycastHit hit;
    static int blinkCounter = 0;
    public delegate void myFunc();
    private void Start()
    {


    }

    private void Update()
    {

        RaycastHit hit;
        

        myEyeStruct = FoveInterface.CheckEyesClosed();
        gcd = FoveInterface.GetGazeConvergence();
        


        if (!prevgcd.Equals(gcd) || prev == "")
        {
            Physics.Raycast(gcd.ray, out hit, Mathf.Infinity);
            transform.position = hit.point;
            prevgcd = gcd;
            //Debug.Log("(accuracy,distance,ray) " + gcd.accuracy + "  " + gcd.distance + "  " + gcd.ray);
        }
        if (prev == "" || prev != myEyeStruct.ToString())
        {
            prev = myEyeStruct.ToString();
            //Debug.Log(prev);
        }
    
    }
    void BlinkCounter(myFunc variable) {

        if (blinkCounter == 2)
        {
            //doing what u want
            variable();
        }
        else if (blinkCounter <= 3)
        {
            blinkCounter++;
        }
        else
        {
            blinkCounter = 0;
        }

    }
}