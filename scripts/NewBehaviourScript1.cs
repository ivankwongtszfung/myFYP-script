using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public GameObject GUI;
    bool allowGui;
    public GameObject Continue;
    public GameObject Options;
    public GameObject Quit;
    public GameObject category_shop_bed;
    public GameObject category_shop_chair;
    public GameObject returnButton;
    // Use this for initialization
    void Start () {
        allowGui = false;
        GUI.SetActive(false);
        Continue.SetActive(false);
        Options.SetActive(false);
        Quit.SetActive(false);
        category_shop_bed.SetActive(false);
        category_shop_chair.SetActive(false);
        returnButton.SetActive(false);

    }
    void MenuSetup() {
        Continue.SetActive(true);
        Options.SetActive(true);
        Quit.SetActive(true);
        category_shop_bed.SetActive(false);
        category_shop_chair.SetActive(false);
        returnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            allowGui = !allowGui;
            MenuSetup();
        }
        if (allowGui)
        {
            
            GUI.SetActive(true);
        }
        else {
            GUI.SetActive(false);
        }

		
	}
    void OnGUI()
    {
    }
}
