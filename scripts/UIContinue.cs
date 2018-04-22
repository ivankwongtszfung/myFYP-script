using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;// Required when using Event data.
using System.Collections.Generic;
public class UIContinue : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    public UIMenuBar Menu;
    bool isHover = false;
    bool lockButton = true;
    // Use this for initialization

    IEnumerator hideMenu()
    {
        yield return new WaitForSeconds(1.5f);
        if (isHover) {
            Menu.hideMenu();
        }
        lockButton = true;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isHover);
        if (isHover && lockButton) {
            lockButton = false;
            StartCoroutine("hideMenu");
            
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
