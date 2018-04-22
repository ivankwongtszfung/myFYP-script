using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
    public Text priceText;

    // Button designButton;
    // Text name;
    // Image productImage;
    // Text description;
    // Text cost;


    private Item item;
    private scrollData scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, scrollData currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        priceText.text = item.price.ToString();
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(item);
    }
}