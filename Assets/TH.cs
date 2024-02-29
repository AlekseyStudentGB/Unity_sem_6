using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TH : MonoBehaviour
{
    public Text timeText;
    public Text lapsText;
    public Text result;
    private bool startBool = false;
    private float timeStart;
    public Text buttonStartText;
    [SerializeField] GameObject green;
    [SerializeField] GameObject read;

    void Start()
    {
        float[] arr = {7.7f, 1.4f, 5.5f, 6.5f, -0.5f, -0.5f};
        foreach (var item in arr)
        {
            Debug.Log(Mathf.Round(item));
        }
        green.SetActive(false);
        read.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (startBool == true){
            timeText.text = MathF.Round(Time.time-timeStart, 2).ToString();
        }
        //lapsText.text = Mathf.Round((Time.time-4.444f)/10).ToString();
    }
    public void StartLaps(){
        if (startBool != true)
        {   
            startBool = true;
            timeStart = Time.time;
            result.text = "";
            lapsText.text = "0";
            buttonStartText.text = "Stop";
            green.SetActive(true);
            read.SetActive(false);
        }else
        {   
            startBool = false;
            buttonStartText.text = "Start";
            green.SetActive(false);
            read.SetActive(true);
        }


    }

    public void ClickButton(){

        lapsText.text = (int.Parse(lapsText.text)+1).ToString();
    }
    public void FixLaps(){
        if (result.text != null){
            result.text = result.text +"\n"+$"Время круга {lapsText.text}: {timeText.text}"; 
        }else{
            result.text =$"Время круга {lapsText.text}: {timeText.text}"; 
        } 
    }
}
