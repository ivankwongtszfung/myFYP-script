using UnityEngine;
using Fove.Managed;
using System.Collections;

public class FOVE3DCursorLeft : MonoBehaviour
{
    public FoveInterface2 fove;
    FoveInterface2.EyeRays rays;
    EFVR_Eye myEyeStruct;
    RaycastHit hit;
    Collider prev = null;
    bool dragTrigger, rotateTrigger = false;

    // Use this for initialization
    void Start()
    {
    }


    // LateUpdate ensures that the object doesn't lag behind the user's head motion
    void FixedUpdate()
    {
        //set value
        rays = fove.GetGazeRays_Immediate();
        myEyeStruct = FoveInterface.CheckEyesClosed();
        //raycast
        Debug.Log(myEyeStruct.ToString());
        Physics.Raycast(rays.left, out hit, Mathf.Infinity);
        if (fove.Gazecast(hit.collider))
        {
            
            transform.position = hit.point;

            if (hit.point != Vector3.zero) //&& (myEyeStruct == EFVR_Eye.Right || myEyeStruct == EFVR_Eye.Both))
            {
                transform.position = hit.point;
                //send a message to a destination gameobject

                if (prev == null)
                {
                    //set the prev to the current hit collider

                    prev = hit.collider;
                    Debug.Log("hit collider set collider to my object " + prev.GetType());
                    if (prev.GetComponent<timerScript>() != null)
                        prev.SendMessage("StartTimer");


                }
                else if (prev.name != hit.collider.name)
                {
                    if (prev.GetComponent<timerScript>() != null)
                        prev.SendMessage("StopTimer");

                    if (hit.collider.GetComponent<timerScript>() != null)
                        hit.collider.SendMessage("StartTimer");

                    prev = hit.collider;
                }


            }
        }
        

        


    }
    void Update()
    {
        //hit.transform.SendMessage("CursorEnter");
        if (prev != null)
        {
            // drag
            if (dragTrigger)
            {
                prev.SendMessage("DragSetRigidBody");
                prev.SendMessage("Drag");
            }
            if (Input.GetKeyDown("z"))
            {
                dragTrigger = !dragTrigger;
                Debug.Log("drag trigger set to:" + dragTrigger);
                if (!dragTrigger)
                {
                    prev.SendMessage("DragRemoveRigidBody");
                }
            }

            // rotate
            if (rotateTrigger)
            {
                prev.SendMessage("RotateSetRigidBody");
                prev.SendMessage("Rotate");
            }
            if (Input.GetKeyDown("x"))
            {
                rotateTrigger = !rotateTrigger;
                Debug.Log("rotate trigger set to:" + rotateTrigger);
                if (!rotateTrigger)
                {
                    prev.SendMessage("RotateRemoveRigidBody");
                }
            }
        }
    }
}
