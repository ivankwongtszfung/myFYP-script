using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenechange : MonoBehaviour {
    string[] scene;
    public int sceneId;
    public FoveInterface2 fove;
    Collider my_collider;
    // Use this for initialization
    void Start () {
        scene = new string[2];
        scene[0] = "category_shop_bed";
        scene[1] = "category_shop_chair";
        my_collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update () {
        if (fove.Gazecast(my_collider))
        {
            Debug.Log("123456789");
            Application.LoadLevel(scene[sceneId]);
            
        }
        
	}
}
