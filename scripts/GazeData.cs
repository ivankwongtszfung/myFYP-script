using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GazeData : MonoBehaviour
{
    [System.Serializable]
    public class GazeObject
    {
        public int gid;
        public int pid;
        public int sid;
        public string time_in_second;
        public int visited;
        public string ttff;
        public string time_spent;
        public int fixation;
        public int revisitor;
       


    }
    public class MyGaze
    {
        public string status;
        public GazeObject[] gaze;
        public static MyGaze CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<MyGaze>(jsonString);
        }
    }

    httpRequest myApi;
    MyGaze gazeList;
    bool ready = false;

    private IEnumerator Requesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        gazeList = MyGaze.CreateFromJSON(myApi.getResult());
        Debug.Log(gazeList.status);

    }
    // Use this for initialization
    void Start()
    {
        gazeList = new MyGaze();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getFixationData");
        StartCoroutine(Requesting());
    }
    void Update()
    {
        Debug.Log(myApi.Status());
        if (gazeList.status=="success" && !ready)
        {
            Debug.Log(gazeList.gaze[0].pid);
            Debug.Log(JsonUtility.ToJson(gazeList.gaze[0]).ToString());
            Dictionary<string, string> post = new Dictionary<string, string>() {
                {"1",JsonUtility.ToJson(gazeList.gaze[0]).ToString()}
            };
            Debug.Log(post["1"]);
            //myApi.POST("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/setFixationData",post);
            //StartCoroutine(Requesting());
            ready = true;
        }        
    }
}
