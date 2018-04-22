using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuReturn : MonoBehaviour {
    public FoveInterface2 fove;
    Collider my_collider;
    public GameObject Continue;
    public GameObject Options;
    public GameObject Quit;
    public GameObject category_shop_bed;
    public GameObject category_shop_chair;
    public GameObject returnButton;
    void MenuSetup()
    {
        Continue.SetActive(true);
        Options.SetActive(true);
        Quit.SetActive(true);
        category_shop_bed.SetActive(false);
        category_shop_chair.SetActive(false);
        returnButton.SetActive(false);
    }
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
            MenuSetup();
        }
    }
}
