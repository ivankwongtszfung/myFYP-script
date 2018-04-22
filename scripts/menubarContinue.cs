using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubarContinue : MonoBehaviour {
    public GameObject menuBar;
    public FoveInterface2 fove;
    Collider my_collider;
    // Use this for initialization
    void Start()
    {
        my_collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fove.Gazecast(my_collider))
        {
            menuBar.SetActive(false);
        }
    }
}
