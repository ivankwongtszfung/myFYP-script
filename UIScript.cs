using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour
{
    Button btn;
    public bool hightlight;
    public static int currId;
    //public FoveInterface2 fove;
    GazeData.GazeObject myGazeObject;
    GazeData myGaze;


    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        hightlight = false;
        currId = 0;
        myGaze= gameObject.GetComponentInParent(typeof(GazeData)) as GazeData;

    }

    void updateData()
    {
        myGazeObject = GazeData.getGazeData(currId);
        Debug.Log("uiscript" + myGazeObject);
        Debug.Log("id " + currId + " gameobject name "+ gameObject.name+"gameobject pid "+ myGazeObject.pid);

        switch (gameObject.name)
        {
            case "pid":
                transform.GetComponentsInChildren<Text>()[0].text = myGazeObject.name.ToString();
                break;
            case "time_in_second":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.time_in_second.ToString();
                break;
            case "visited":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.visited.ToString();
                break;
            case "ttff":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.ttff.ToString();
                break;
            case "time_spent":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.time_spent.ToString();
                break;
            case "fixation":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.fixation.ToString();
                break;
            case "revisitor":
                transform.GetComponentsInChildren<Text>()[1].text = myGazeObject.revisitor.ToString();
                break;
            case "aoiImage":
                //since image is in button level so no need to go down to search
                transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myGazeObject.pid.ToString());
                break;
        }
    }

    private void FixedUpdate()
    {

        var pointer = new PointerEventData(EventSystem.current);



        if (Input.GetKeyDown(KeyCode.H) /*|| fove.Gazecast(GetComponent<Collider>())*/)
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        }
        else
        {
            //ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        }
        if (Input.GetKeyDown("space") && hightlight /*&& fove.Gazecast(GetComponent<Collider>())*/ )
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.submitHandler);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerUpHandler);
        }



    }

    void CursorEnter()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        hightlight = true;
        Debug.Log("highlight function called"+ hightlight);
    }

    void CursorExit()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        hightlight = false;
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
            
            case "next":
                maxLength = GazeData.gazeList.gaze.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                currId++;
                if (currId == maxLength)
                {
                    currId = 0;
                }
                myGaze.UpdateBoardcast();
                break;
            case "prev":
                maxLength = GazeData.gazeList.gaze.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                currId--;
                if (currId < 0)
                {
                    currId = maxLength-1;
                }
                myGaze.UpdateBoardcast();
                break;
            default:
                if(transform.parent.Find("aoiImage").GetComponent<Image>().fillAmount == 0)
                    transform.parent.Find("aoiImage").GetComponent<Image>().fillAmount = 1;
                else
                    transform.parent.Find("aoiImage").GetComponent<Image>().fillAmount = 0;
                break;
        }
        
        Debug.Log("Update Success!");
    }
}
