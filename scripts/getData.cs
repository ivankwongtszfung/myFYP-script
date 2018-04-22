
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour {
    private string results;
    private string[] data;
    public GUIStyle style;
    public string GET(string url)
    {

        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
        
        return www.text;
    }

    public WWW POST(string url, Dictionary<string, string> post, System.Action onComplete)
    {
        WWWForm form = new WWWForm();

        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
        return www;
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text.Split(','));
            Debug.Log("WWW Ok!: " + www.text);
            results = www.text;
        }
        else
        {
            Debug.Log("WWW not ok!: ");
        }
    }

    public string getProductData(string data) {
        return data;
    }

    // Use this for initialization
    void Start () {
        


    }
	
    string[] getDataValue(string data) {
        string []value = data.Split('|');
        return value;
    }
    
}
