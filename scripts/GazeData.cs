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

    public static GazeObject getGazeData(int id)
    {
        return gazeList.gaze[id];
    }

    public void uploadGazeData(int id)
    {
        Dictionary<string, string> post = new Dictionary<string, string>() {
                {"1",JsonUtility.ToJson(gazeList.gaze[0]).ToString()}
            };
        Debug.Log(post["1"]);
        myApi.POST("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/setFixationData", post);
        StartCoroutine(postRequesting());
    }

    httpRequest myApi;
    static MyGaze gazeList;
    bool ready = false;

    private IEnumerator getRequesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        gazeList = MyGaze.CreateFromJSON(myApi.getResult());
        Debug.Log(gazeList.status);

    }

    private IEnumerator postRequesting()
    {
        yield return myApi.httpResponse;
        Debug.Log(myApi.getResult());

    }
    // Use this for initialization
    void Start()
    {
        gazeList = new MyGaze();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getFixationData");
        StartCoroutine(getRequesting());
    }

}
