using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBarOption : MonoBehaviour {
    public GameObject Continue;
    public GameObject Options;
    public GameObject Quit;
    public GameObject category_shop_bed;
    public GameObject category_shop_chair;
    public GameObject returnButton;
    public FoveInterface2 fove;
    Collider my_collider;
    // Use this for initialization
    void Start () {
        my_collider = GetComponent<Collider>();
        category_shop_bed.SetActive(false);
        category_shop_chair.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (fove.Gazecast(my_collider))
        {
            Continue.SetActive(false);
            Options.SetActive(false);
            Quit.SetActive(false);
            category_shop_bed.SetActive(true);
            category_shop_chair.SetActive(true);
            returnButton.SetActive(true);
        }
    }
}
