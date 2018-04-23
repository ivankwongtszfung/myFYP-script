using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cart : MonoBehaviour
{

    httpRequest myApi;
    public static MyCart CartList;
    bool ready = false;
    static Dictionary<int, UploadCart> uploadCart;


    [System.Serializable]
    public class CartObject
    {
        public int pid;
        public int cat_id;
        public int user_id;
        public int sid;
        public string cat_name;
        public string name;
        public string model_name;
        public string description;
        public float cost;
    }

    public class UploadCart
    {
        public int user_id;
        public int pid;
    }

    public class MyCart
    {
        public string status;
        public CartObject[] cart;
        public static MyCart CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<MyCart>(jsonString);
        }
    }
    private IEnumerator getRequesting()
    {
        yield return myApi.httpResponse;
        //Debug.Log(myApi.getResult());
        CartList = MyCart.CreateFromJSON(myApi.getResult());
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
        CartList = new MyCart();
        gameObject.AddComponent<httpRequest>();
        myApi = gameObject.GetComponent<httpRequest>();
        myApi.GET("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/getCartData");
        StartCoroutine(getRequesting());
    }

    public static CartObject getPreference(int id)
    {
        return CartList.cart[id];
    }


    void uUploadCartData()
    {
        Dictionary<string, string> post = new Dictionary<string, string>();
        foreach (KeyValuePair<int, UploadCart> singleCart in uploadCart)
        {
            if (!post.ContainsKey(singleCart.Key.ToString()))
            {
                post.Add(singleCart.Key.ToString(), JsonUtility.ToJson(singleCart.Value).ToString());
            }
            else
            {
                post[singleCart.Key.ToString()] = JsonUtility.ToJson(singleCart.Value).ToString();
            }
            Debug.Log(post[singleCart.Key.ToString()]);
        }

        foreach (KeyValuePair<string, string> single in post)
        {
            Debug.Log(single.ToString());
        }

        //myApi.POST("http://ec2-52-15-84-235.us-east-2.compute.amazonaws.com/myFYP/public/api/setCartData", post);
        //StartCoroutine(postRequesting());
    }

    private IEnumerator postRequesting()
    {
        yield return myApi.httpResponse;
        Debug.Log(myApi.getResult());

    }

    public static CartObject getCart(int id)
    {
        if (CartList.cart.Length > id)
        {
            return CartList.cart[id];
        }
        else
        {
            return null;
        }
        

    }

}
