using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hit.transform.SendMessage("CursorEnter");
            if (Input.GetKeyDown("z"))
            {
                hit.transform.SendMessage("ClickFunction");
            }
            
            //hit.transform.GetComponent<timerScript>().startCounting();
            if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
            {
               // Debug.Log(hit.point);
                transform.position = hit.point;
            }
        }
    }
}
