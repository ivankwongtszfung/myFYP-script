using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag_obj : MonoBehaviour
{
    public GameObject cursor;
    float posX;
    float posZ;
    Rigidbody rb;
    Vector3 trigger_pos;
    //bool trigger;

    void Start()
    {
        //trigger = false;
    }

    void DragSetRigidBody()
    {
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void DragRemoveRigidBody()
    {
        //Destroy(GetComponent<Rigidbody>());
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<MeshCollider>().convex = false;
    }

    void Drag()
    {
        Debug.Log("drag object is focus");

        //GetComponent<MeshCollider>().convex = true;
        //GetComponent<MeshCollider>().isTrigger = true;

        rb = GetComponent<Rigidbody>();
        /*if(trigger)
        {
            transform.position = trigger_pos;
            rb.constraints = RigidbodyConstraints.None;
            trigger = false;
        }*/

        Vector3 pos_move = new Vector3(cursor.transform.position.x, transform.position.y, cursor.transform.position.z);
        rb.velocity = new Vector3(pos_move.x - transform.position.x, 0, pos_move.z - transform.position.z) * 10;
        //transform.position= new Vector3(cursor.transform.position.x, transform.position.y, cursor.transform.position.z);
        //Vector3 movement = new Vector3(pos_move.x - transform.position.x, 0, pos_move.z - transform.position.z) * 10 * Time.deltaTime;
        //rb.MovePosition(transform.position + movement);
        //Debug.Log(pos_move + ":" + rb.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter");
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
    /*void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Player on trigger");
            rb.constraints = RigidbodyConstraints.FreezePosition;
            trigger_pos = transform.position;
            trigger = true;
        }
    }*/
}
