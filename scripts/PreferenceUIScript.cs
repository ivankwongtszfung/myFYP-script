using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PreferenceUIScript : MonoBehaviour
{

    Image img;
    Button btn;
    public bool hightlight, fixation;
    public float fixationDuration;
    float fixationAmount;
    public static int currId;

    public GameObject platform;

    Preference.PreferenceObject myPreferenceObject;
    Preference myPreference;

    Queue sortMode;


    // Use this for initialization
    void Start()
    {

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        hightlight = false;
        fixation = false;
        currId = 0;
        myPreference = gameObject.GetComponentInParent(typeof(Preference)) as Preference;
        if (fixationDuration <= 0)
        {
            fixationDuration = 3;
        }


        sortMode = new Queue();
        sortMode.Enqueue("timespent most");
        sortMode.Enqueue("fixation most");
        sortMode.Enqueue("visited most");
        sortMode.Enqueue("revisit most");


    }

    void updateData()
    {

        myPreferenceObject = Preference.getPreference(currId);
        Debug.Log("uiscript" + myPreferenceObject);
        Debug.Log("id " + currId + " gameobject name " + gameObject.name + "gameobject pid " + myPreferenceObject.pid);

        switch (gameObject.name)
        {
            case "header":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.pid.ToString();
                break;
            case "time_in_second":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.time_in_second.ToString();
                break;
            case "total_visited":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.total_visited.ToString();
                break;
            case "model_name":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.model_name.ToString();
                break;
            case "total_time_spent":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.total_time_spent.ToString();
                break;
            case "total_fixation":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.total_fixation.ToString();
                break;
            case "total_revisiter":
                transform.GetComponentsInChildren<Text>()[1].text = myPreferenceObject.total_revisiter.ToString();
                break;
            case "PreferenceImage":
                //since image is in button level so no need to go down to search
                transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myPreferenceObject.pid.ToString());
                break;
        }
    }

    private void FixedUpdate()
    {

        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetKeyDown("space") && hightlight /*&& fove.Gazecast(GetComponent<Collider>())*/ )
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.submitHandler);
        }


    }

    private bool validFillObject()
    {
        return gameObject.name == "next-pref" || gameObject.name == "prev-pref" || gameObject.name == "header";
    }


    private void Update()
    {
        if (fixation && validFillObject())
        {
            if (fixationAmount < fixationDuration)
            {
                fixationAmount += Time.deltaTime;
                //the image is in the first button child

                transform.GetComponentsInChildren<Button>()[1].GetComponent<Image>().fillAmount = (fixationAmount / fixationDuration);
            }
            else
            {
                var pointer = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.submitHandler);
                fixationAmount = 0;
            }
        }

    }

    void CursorEnter()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        hightlight = true;
        fixation = true;
        Debug.Log("highlight function called" + hightlight);
    }

    void CursorExit()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        hightlight = false;
        fixation = false;
        if (validFillObject())
        {
            fixationAmount = 0;
            transform.GetComponentsInChildren<Button>()[1].GetComponent<Image>().fillAmount = 0;
        }
        
        Debug.Log("highlight function called" + hightlight);

    }


    void click()
    {
        if (hightlight /*&& fove.Gazecast(GetComponent<Collider>())*/ )
        {
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.submitHandler);
        }
    }

    void showInitData()
    {
        GazeData.getGazeData(1);

    }

    void ClickFunction()
    {
        btn.onClick.Invoke();
    }

    void TaskOnClick()
    {

        int maxLength;
        switch (gameObject.name)
        {

            case "next-pref":
                maxLength = Preference.PreferenceList.preference.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                currId++;
                if (currId == maxLength)
                {
                    currId = 0;
                }
                myPreference.UpdateBoardcast();
                break;
            case "prev-pref":
                maxLength = Preference.PreferenceList.preference.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                currId--;
                if (currId < 0)
                {
                    currId = maxLength - 1;
                }
                myPreference.UpdateBoardcast();
                break;
            case "PreferenceImage":
                Instantiate(GameObject.Find(myPreferenceObject.model_name), platform.transform);
                break;
            case "header":
                //sorting by different attribute
                object data = sortMode.Dequeue();
                sortMode.Enqueue(data);
                //since we only change header so we will do it here
                transform.GetComponentsInChildren<Text>()[0].text = data.ToString();
                break;
        }

        Debug.Log("Update Success!");
    }
}
