using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class httpRequest : MonoBehaviour
{
    public WWW httpResponse;
    private String result;
    // Use this for initialization
    public void  GET(string url)
    {

        httpResponse = new WWW(url);
        StartCoroutine(WaitForRequest(httpResponse));

    }

    public void POST(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();

        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }


        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text.Split(','));
            Debug.Log("http response!!");
            httpResponse = www;
            result = www.text;
            Debug.Log(www.text);
        }
        else
        {
            Debug.Log(String.Format("http error: {0}", www.error));

        }
    }



    public bool Status()
    {
        return httpResponse.isDone;
    }

    public string getResult()
    {
        if (httpResponse.isDone)
            return httpResponse.text;
        else
            return "Response is not received yet";

    }



    private void Start()
    {
    }




}
