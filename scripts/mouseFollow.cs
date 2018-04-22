using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseFollow : MonoBehaviour
{
    public float distance = 1.0f;
    public bool cameraDistance = false;
    private float actualDistance;
    // Use this for initialization
    void Start()
    {
        if (cameraDistance)
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 lineaerDistanceVector = Vector3.Project(toObjectVector,Camera.main.transform.forward);
            actualDistance = (transform.position - Camera.main.transform.position).magnitude;
        }
        else
        {
            actualDistance = distance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePostion = Input.mousePosition;
        mousePostion.z = actualDistance;
        //we will fix the mouse z position 
        transform.position = Camera.main.ScreenToWorldPoint(mousePostion);
    }
}
