using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayFollow : MonoBehaviour {

    Collider prev,next;
	// Use this for initialization
	void Start () {
        prev = null;
        next = null;
    }
   
    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            transform.position = hit.transform.position;
            next = hit.collider;
            
            if (prev == null)
            {
                if (hit.collider.GetComponent<UIScript>() != null)
                {
                    prev = hit.collider;
                    Debug.Log(hit.collider.GetComponent<UIScript>().hightlight);
                    if (hit.collider.GetComponent<UIScript>().hightlight == false)
                    {
                        hit.transform.SendMessage("CursorEnter");
                    }
                }
                else if (hit.collider.GetComponent<PreferenceUIScript>() != null)
                {
                    prev = hit.collider;
                    Debug.Log(hit.collider.GetComponent<PreferenceUIScript>().hightlight);
                    if (hit.collider.GetComponent<PreferenceUIScript>().hightlight == false)
                    {
                        hit.transform.SendMessage("CursorEnter");
                    }
                }
                else if (hit.collider.GetComponent<timerScript>() != null)
                {
                    prev = hit.collider;
                    Debug.Log(hit.collider.GetComponent<timerScript>().CursorTriggered);
                    if (hit.collider.GetComponent<timerScript>().CursorTriggered == false)
                    {
                        hit.transform.SendMessage("StartTimer");
                    }
                }
            }
            else if (next.name != prev.name)
            {
                if (prev.GetComponent<UIScript>() != null)
                {
                    if (prev.GetComponent<UIScript>().hightlight)
                    {
                        prev.transform.SendMessage("CursorExit");
                    }
                }
                else if (prev.GetComponent<PreferenceUIScript>() != null)
                {
                    if (prev.GetComponent<PreferenceUIScript>().hightlight)
                    {
                        prev.transform.SendMessage("CursorExit");
                    }
                }
                else if (prev.GetComponent<timerScript>() != null)
                {
                    if (prev.GetComponent<timerScript>().CursorTriggered)
                    {
                        prev.transform.SendMessage("StopTimer");
                    }
                }


                if (hit.collider.GetComponent<UIScript>() != null)
                {
                    prev = hit.collider;
                    if (hit.collider.GetComponent<UIScript>().hightlight == false)
                    {
                        hit.transform.SendMessage("CursorEnter");
                    }
                }
                else if (hit.collider.GetComponent<PreferenceUIScript>() != null)
                {
                    prev = hit.collider;
                    Debug.Log(hit.collider.GetComponent<PreferenceUIScript>().hightlight);
                    if (hit.collider.GetComponent<PreferenceUIScript>().hightlight == false)
                    {
                        hit.transform.SendMessage("CursorEnter");
                    }

                }
                else if (hit.collider.GetComponent<timerScript>() != null)
                {
                    prev = hit.collider;
                    Debug.Log(hit.collider.GetComponent<timerScript>().CursorTriggered);
                    if (hit.collider.GetComponent<timerScript>().CursorTriggered == false)
                    {
                        hit.transform.SendMessage("StartTimer");
                    }
                }
            }
            
            
        }
    }
}
