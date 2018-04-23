using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GazeData : MonoBehaviour
{


    httpRequest myApi;
    public static MyGaze gazeList;
    bool ready = false;
    static Dictionary<int, GazeObject> uploadGaze;
    static float timeOffset;


    [System.Serializable]
    public class GazeObject
    {
        public int gid;
        public int pid;
        public int sid;
        public float time_in_second;
        public string name;
        public int visited;
        public float ttff;
        public float time_spent;
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

    void uploadGazeData()
    {
        Dictionary<string, string> post = new Dictionary<string, string>();
        foreach (KeyValuePair<int,GazeObject> singleGaze in uploadGaze)
        {
            if (!post.ContainsKey(singleGaze.Key.ToString()))
            {
                post.Add(singleGaze.Key.ToString(), JsonUtility.ToJson(singleGaze.Value).ToString());
            }
            else
            {
                post[singleGaze.Key.ToString()] = JsonUtility.ToJson(singleGaze.Value).ToString();
            }
            Debug.Log(post[singleGaze.Key.ToString()]);
        }

        foreach (KeyValuePair<string, string> single in post)
        {
            Debug.Log(single.ToString());
        }

        //myApi.POST("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/setFixationData", post);
        //StartCoroutine(postRequesting());
    }


    private IEnumerator getRequesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        gazeList = MyGaze.CreateFromJSON(myApi.getResult());
        UpdateBoardcast();



    }

    public void UpdateBoardcast()
    {
        BroadcastMessage("updateData");
        Debug.Log("boardcast finish!");
    }

    private IEnumerator postRequesting()
    {
        yield return myApi.httpResponse;
        Debug.Log(myApi.getResult());

    }
    // Use this for initialization
    void Awake()
    {
        gazeList = new MyGaze();
        uploadGaze = new Dictionary<int, GazeObject>();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getFixationData");
        StartCoroutine(getRequesting());
        timeOffset=Time.realtimeSinceStartup;
    }

    private void OnApplicationQuit()
    {
        uploadGazeData();
    }

    public static void setGazeById(int id,int visited,string ttff,float time_spent,int fixation,int revisitor)
    {
        if (!uploadGaze.ContainsKey(id))
        {
            Debug.Log("create id " + id);
            uploadGaze.Add(id, new GazeObject());
            uploadGaze[id].ttff = Time.realtimeSinceStartup - timeOffset;
            uploadGaze[id].pid = id;
            uploadGaze[id].revisitor = revisitor;
        }
        uploadGaze[id].visited = visited;
        uploadGaze[id].time_spent += time_spent;
        uploadGaze[id].time_in_second += time_spent;
        uploadGaze[id].fixation = fixation;
    }
}
