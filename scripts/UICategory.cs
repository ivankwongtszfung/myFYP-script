using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;// Required when using Event data.
using System.Collections.Generic;
public class UICategory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    public UIMenuBar Menu;
    bool isHover = false;
    bool lockButton = true;
    // Use this for initialization

    IEnumerator OptionMenu()
    {
        yield return new WaitForSeconds(1.5f);
        if (isHover)
        {
            Menu.getOptionMenu();
        }
        lockButton = true;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHover && lockButton) {
            lockButton = false;
            StartCoroutine("OptionMenu");
        }
            
            
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }
}
