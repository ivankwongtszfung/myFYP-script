using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DetailGUI : MonoBehaviour {
    public Product productInstance;
    public Text ProductName;
    public Text Description;
    public Text Category;
    public Text Cost;
    public static bool show = false;
    Product.ProductObject data;
    //public void setShow(bool showDetail) {
    //    DetailGUI.show = showDetail;
    //}
    //public void toggleShow() {
    //    DetailGUI.show = !DetailGUI.show;
    //}
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}
    //load data in the front-end
    void loadDataToView()
    {   
        ProductName.text = data.name;
        Cost.text = "$"+data.cost.ToString();
        string cat = "Category: " + data.cat_name+"\n";
        Description.text = cat+"Description: " +data.description;
        
    }
    public void setProductDetail(int id) {
        data = productInstance.GetProductById(id);
        loadDataToView();
        gameObject.SetActive(true);
    }

    public void hideProductWindow() {
        gameObject.SetActive(false);
    }


}

