using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helloWorld : MonoBehaviour {

    float speed = 0.25f;
    private void Move()
    {
        Vector3 myMove = new Vector3(1.0f, 0.0f, 0.0f) * speed;
        transform.Translate(myMove);
    }

    private void Rotate()
    {
        Vector3 myRotate = new Vector3(0.0f, 0.0f, 1.0f);
        transform.Rotate(myRotate);
    }

    private void logging() {
        Debug.Log(this.transform.position);
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Transform Object");

        Transform myTransform = this.transform;
        Move();
        logging();



    }

    
	// Update is called once per frame
	void Update () {
        Debug.Log("Hello World");
        speed = Time.deltaTime;
        Move();
        Rotate();
        logging();
    }
}
