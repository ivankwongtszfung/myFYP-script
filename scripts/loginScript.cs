using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginScript : MonoBehaviour {
    public GameObject username, password, submit,error;
    public string scene;
	// Use this for initialization
	void Start () {
        error.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            else if (password.GetComponent<InputField>().isFocused)
            {
                submit.GetComponent<Button>().Select();
            }
        }
        else if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
        {
            if (username.GetComponent<InputField>().text == "cwf1703")
            {
                LoadScene(scene);
            }
            else
            {
                error.SetActive(true);
            }
            
        }
	}

    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
        //go to another scene
    }
}
