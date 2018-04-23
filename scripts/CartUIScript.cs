using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CartUIScript : MonoBehaviour
{

    Image img;
    Button btn;
    public bool hightlight, fixation;
    public float fixationDuration;
    public GameObject menu;
    float fixationAmount;
    public static int page;

    public GameObject platform;

    Cart.CartObject myCartObject;
    Cart myCart;

    Queue sortMode;


    // Use this for initialization
    void Start()
    {

        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        hightlight = false;
        fixation = false;
        page = 0; //the photo would be stored in the list  this is the page
        myCart = gameObject.GetComponentInParent(typeof(Cart)) as Cart;
        if (fixationDuration <= 0)
        {
            fixationDuration = 3;
        }
    }

    void updateData()
    {



        switch (gameObject.name)
        {
            case "cancel":

                break;
            case "image NW":
                myCartObject = Cart.getCart(0 + 4 * page);
                if (myCartObject != null)
                {
                    transform.GetComponent<Image>().fillAmount = 1;
                    transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myCartObject.pid.ToString());
                    transform.GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    transform.GetComponent<Image>().fillAmount = 0;
                    transform.GetComponentInChildren<Text>().text = "Slot One";
                }
                break;
            case "image NE":
                //since image is in button level so no need to go down to search
                myCartObject = Cart.getCart(1 + 4 * page);
                if (myCartObject != null)
                {
                    transform.GetComponent<Image>().fillAmount = 1;
                    transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myCartObject.pid.ToString());
                    transform.GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    transform.GetComponent<Image>().fillAmount = 0;
                    transform.GetComponentInChildren<Text>().text = "Slot Two";
                }
                break;
            case "image SW":
                myCartObject = Cart.getCart(2 + 4 * page);
                if (myCartObject != null)
                {
                    transform.GetComponent<Image>().fillAmount = 1;
                    transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myCartObject.pid.ToString());
                    transform.GetComponentInChildren<Text>().text = "";
                }
                else
                {
                    transform.GetComponent<Image>().fillAmount = 0;
                    transform.GetComponentInChildren<Text>().text = "Slot Three";
                }
                break;
            case "image SE":
                myCartObject = Cart.getCart(3 + 4 * page);
                if (myCartObject != null)
                {
                    transform.GetComponent<Image>().fillAmount = 1;
                    transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(myCartObject.pid.ToString());
                    transform.GetComponentInChildren<Text>().text = "";
                }
                else {
                    transform.GetComponent<Image>().fillAmount = 0;
                    transform.GetComponentInChildren<Text>().text = "Slot Four";
                }
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
        return gameObject.name == "next-pref" || gameObject.name == "prev-pref" || gameObject.name == "header" || gameObject.name == "cancel";
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
        if (Input.GetKeyDown("escape"))
        {
            menu.SetActive(true);
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
                maxLength = Cart.CartList.cart.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                page++;
                if (page*4 > maxLength)
                {
                    page = 0;
                }
                myCart.UpdateBoardcast();
                break;
            case "prev-pref":
                maxLength = Cart.CartList.cart.Length;
                Debug.Log("You have clicked the button! MaxLength " + maxLength + " " + gameObject.name);
                page--;
                if (page < 0)
                {
                    page = (maxLength/4);
                }
                myCart.UpdateBoardcast();
                break;
            case "CartImage":
                Instantiate(GameObject.Find(myCartObject.model_name), platform.transform);
                break;
            case "header":
                //sorting by different attribute
                object data = sortMode.Dequeue();
                sortMode.Enqueue(data);
                //since we only change header so we will do it here
                transform.GetComponentsInChildren<Text>()[0].text = data.ToString();
                break;
            case "cancel":
                menu.SetActive(false);
                break;
        }

        Debug.Log("Update Success!");
    }
}
