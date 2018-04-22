using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour
{
    Button btn;
    bool hightlight;
    public FoveInterface2 fove;

    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    private void Update()
    {
        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetKeyDown(KeyCode.H) || fove.Gazecast(GetComponent<Collider>()))
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        }
        else
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        }
        if (Input.GetKeyDown("space") && fove.Gazecast(GetComponent<Collider>()))
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

    void ClickFunction()
    {
        btn.onClick.Invoke();
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
