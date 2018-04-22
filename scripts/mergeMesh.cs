using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class initialPosition
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
    public initialPosition(Vector3 p, Quaternion r,Vector3 s) {
        pos = p;
        rot = r;
        scale = s;
    }
    public void setPosition(Transform t) {
        t.position = pos;
        t.rotation = rot;
        t.localScale = scale;
    }
}
public class mergeMesh : MonoBehaviour {

    // Use this for initialization

    void Start()
    {

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshCollider>();
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        if (!gameObject.GetComponent<MeshRenderer>()) {
            gameObject.AddComponent<MeshRenderer>();
        }
        initialPosition ip = new initialPosition(transform.position, transform.rotation, transform.localScale);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length-1];
        Material[] myMaterials = new Material[meshFilters.Length-1];
        

        int index = 0;

        foreach (MeshFilter child in meshFilters)
        {

            if (child == gameObject.GetComponent<MeshFilter>())
            {
                //skip self gameobject
                continue;       
            }
            
            child.transform.position += transform.position;
            
            //Debug.Log(index);
            //Debug.Log("transform position:"+transform.position);
            //child.transform.position += transform.position;
            //Debug.Log("child transform position:" + child.transform.position);
            //MeshFilter[] meshFilters = child.GetComponents<MeshFilter>();

            if (child.sharedMesh == null) continue;
            combine[index].mesh = child.sharedMesh;
            combine[index].transform = child.transform.localToWorldMatrix;
            if (child.GetComponent<MeshCollider>())
                child.GetComponent<MeshCollider>().enabled = false;
            else
                Debug.Log(child.name+":"+child.transform.localPosition);
            myMaterials[index] = child.GetComponent<Renderer>().material;
            index++;
        }
        ip.setPosition(transform);
        GetComponent<MeshFilter>().mesh = new Mesh();
        GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        GetComponent<MeshFilter>().sharedMesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
