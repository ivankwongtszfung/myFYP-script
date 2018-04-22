using UnityEngine;
using Fove.Managed;
using System.Collections;

public class FOVE3DCursorRight : MonoBehaviour {
    public FoveInterface2 fove;
    FoveInterface2.EyeRays rays;
    EFVR_Eye myEyeStruct;
    RaycastHit hit;
    // Use this for initialization
    void Start () {
	}

    // Latepdate ensures that the object doesn't lag behind the user's head motion
    void Update() {
        //set value
        rays = fove.GetGazeRays_Immediate();
        myEyeStruct = FoveInterface.CheckEyesClosed();
        //raycast
        Physics.Raycast(rays.right, out hit, Mathf.Infinity);

        if (hit.point != Vector3.zero) //&& (myEyeStruct == EFVR_Eye.Left || myEyeStruct == EFVR_Eye.Both))
        {
            transform.position = hit.point;
        }
    }
}
