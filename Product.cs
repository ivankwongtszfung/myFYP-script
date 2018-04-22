using UnityEngine;
using System.Collections;



public class Product : MonoBehaviour
{

    [System.Serializable]
    public class ProductObject
    {
        public int pid;
        public string cat_name;
        public string name;
        public string model_name;
        public string description;
        public float cost;

    }
    public class MyProduct
    {
        public string status;
        public ProductObject[] product;
        public static MyProduct CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<MyProduct>(jsonString);
        }
    }

    public ProductObject GetProductById(int id) {
        if (myApi.Status())
            return productList.product[id];
        else
            return null;
    }

    httpRequest myApi;
    MyProduct productList;
    bool ready = false;

    private IEnumerator Requesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        productList = MyProduct.CreateFromJSON(myApi.getResult());
        Debug.Log(productList.product[0].cost);

    }
    // Use this for initialization
    void Start()
    {
        productList = new MyProduct();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getAllProduct");
        StartCoroutine(Requesting());
    }

}
