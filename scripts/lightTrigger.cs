using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightTrigger : MonoBehaviour {

    Collider myCollider;
    Light myLight;
    // Use this for initialization
    void Start () {
        myLight = GetComponent<Light>();
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        myCollider = GetComponent<Collider>();
        myLight.enabled = true;


    }

	// Update is called once per frame
	void Update () {
        //Here the GameObject's Collider is not a trigger
        if (myCollider.isTrigger)
        {
            
            //Output whether the Collider is a trigger type Collider or not
           // Debug.Log("Trigger On : " + myCollider.isTrigger);
        }
        else {
            //Debug.Log("Trigger On : " + myCollider.isTrigger);
        }

	}




}
