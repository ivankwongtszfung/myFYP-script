using UnityEngine;
using System.Collections;

public class Preference : MonoBehaviour
{
    httpRequest myApi;
    public static MyPreference PreferenceList;
    bool ready = false;


    [System.Serializable]
    public class PreferenceObject
    {
        public int pid;
        public string model_name;
        public string time_in_second;
        public int total_visited;
        public string total_time_spent;
        public int total_fixation;
        public int total_revisiter;
    }

    public class MyPreference
    {
        public string status;
        public PreferenceObject[] preference;
        public static MyPreference CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<MyPreference>(jsonString);
        }
    }
    private IEnumerator getRequesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        PreferenceList = MyPreference.CreateFromJSON(myApi.getResult());
        UpdateBoardcast();

    }

    public void UpdateBoardcast()
    {
        BroadcastMessage("updateData");
        Debug.Log("boardcast finish!");
    }

    // Use this for initialization
    void Awake()
    {
        PreferenceList = new MyPreference();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getGeneralPreferenceList");
        StartCoroutine(getRequesting());
    }

    public static PreferenceObject getPreference(int id)
    {
        return PreferenceList.preference[id];
    }

    public static void sortPreference()
    {

    }


}
