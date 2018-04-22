using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour {
    public Transform mainMenu, optionMenu;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadScene(string name) {
        Application.LoadLevel(name);
        //go to another scene
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void login(bool clicked) {
        if (clicked)
        {
            optionMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            optionMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(clicked);
        }
    }
}
