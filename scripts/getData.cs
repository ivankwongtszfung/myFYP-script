
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour {
    private string results;
    private string[] data;
    public GUIStyle style;
    public WWW GET(string url)
    {

        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
        return www;
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

    public Vector2 scrollPosition;

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text.Split(','));
            Debug.Log("WWW Ok!: " + www.text);
            results = www.text;
            data=results.Split(';');
        }
        else
        {
            Debug.Log(www.error);
        }
    }
    // Use this for initialization
    void Start () {
        GET("http://localhost/api/getAllProduct");


    }
	
    string[] getDataValue(string data) {
        string []value = data.Split('|');
        return value;
    }
    void OnGUI()
    {
        // Make a background box
        GUILayout.Box("Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        string[] i = getDataValue(data[0]);
        //style = GUI.skin.box;
        //GUI.skin.label = style;
        for (int count = 0; count < i.Length; count++)
        {
            if (count == 2)
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(100), GUILayout.Height(100));
                GUILayout.Label(i[count]);
                //scrollPosition = GUILayout.BeginScrollView(scrollPosition,false,true, GUILayout.Width(200), GUILayout.Height(100));
                GUILayout.EndScrollView();
            }
            else {
                GUILayout.Box(i[count]);
            }
            
        }
    }
}
