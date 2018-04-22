using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rotate_obj : MonoBehaviour
{
    public GameObject cursor;
    // float rotate_speed = 5f;
    Rigidbody rb;
    Vector3 angular_velocity;
    Vector3 obj_screen_pos;
    Vector3 cursor_screen_pos;
    Quaternion deltaRotation;

    void Start()
    {
    }

    void RotateSetRigidBody()
    {
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    void RotateRemoveRigidBody()
    {
        //Destroy(GetComponent<Rigidbody>());
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<MeshCollider>().convex = false;
    }

    void Rotate()
    {
        rb = GetComponent<Rigidbody>();

        // Vector3 direction = cursor.transform.position - transform.position;
        // float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_speed * Time.deltaTime);
        obj_screen_pos = Camera.main.WorldToScreenPoint(transform.position);
        cursor_screen_pos = Camera.main.WorldToScreenPoint(cursor.transform.position);
        // Debug.Log(cursor_screen_pos.x - obj_screen_pos.x);
        if (cursor_screen_pos.x - obj_screen_pos.x > 0)
        {
            angular_velocity = new Vector3(0, -30, 0);
            deltaRotation = Quaternion.Euler(angular_velocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else
        {
            angular_velocity = new Vector3(0, 30, 0);
            deltaRotation = Quaternion.Euler(angular_velocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}