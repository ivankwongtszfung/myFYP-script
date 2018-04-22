
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class timerScript : MonoBehaviour
{
    int timer_i = 0;
    int time_p = 0;
    public int GUIShow = 5;
    bool start_Timer3, persistentTimer = true;
    bool showGui = true;
    public int pid = 1;
    GameObject detail;
    public FoveInterface2 fove;
    Collider my_collider;
    public DetailGUI detail_s;
    bool ready = true;
    private GameObject CursorLeft;
    private GameObject CursorRight;
    TimeSpan all;
    DateTime start;
    Collider col;
    float span;
    bool CursorTriggered, TimerStarted = false;
    Time obj;

    void setData() {
        int arrrayIndex = pid - 1;
        detail_s.setProductDetail(arrrayIndex);
    }
    

    IEnumerator timer3()
    {

        yield return new WaitForSeconds(1);
        if (fove.Gazecast(my_collider)) {
            timer_i++;
        }
        
        //Debug.Log(timer_i);
        if (timer_i > GUIShow && fove.Gazecast(my_collider))
        {
            //Debug.Log("show GUI");
            StartCoroutine("DetailLifeTime");
            timer_i = 0;
        }
        start_Timer3=true;
    }

    IEnumerator DetailLifeTime()
    {
        time_p++;
        //Debug.Log(time_p);
        if (timer_i > GUIShow)
        {
            //Debug.Log("show GUI");
            setData();
            ready = false;
            time_p = 0;
        }
        yield return new WaitForSeconds(5);
        detail_s.hideProductWindow();
        yield return new WaitForSeconds(50);
        ready = true;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        my_collider = GetComponent<Collider>();
        if (start_Timer3) {
            my_collider = GetComponent<Collider>();
            if (fove == null)
            {
                
            }
            else {
                if (fove.Gazecast(my_collider) && ready )
                {
                    //Debug.Log(DateTime.Now);
                    //Debug.Log(fove.Gazecast(my_collider));
                    StartCoroutine("timer3");
                    start_Timer3 = false;
                }
                else
                {
                    timer_i = 0;
                }
            }

        }

        //adding up the deltatime
        if (CursorTriggered && fove.Gazecast(my_collider))
        {
            //update product cs
            start = DateTime.Now;
            TimerStarted = true;
            span += Time.deltaTime;
            Debug.Log("timerstart" + TimerStarted);
            Debug.Log(span);
        }
        
        


    }
    public void StartTimer()
    {
        CursorTriggered = true;
    }

    public void StopTimer()
    {
        CursorTriggered = false;
    }
 

}


