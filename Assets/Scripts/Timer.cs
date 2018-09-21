using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //display visual timer
    public TextMesh displayText;

    //starting time for the timer
    public float timerDuration;

    //current second remaining on timer
    private float timeRemaining = 0;




	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        //only process if timer is running
		if (IsTimerRunning())
        {
            //timer is running, so process
            timeRemaining = timeRemaining - Time.deltaTime;
            
            if (timeRemaining <= 0)
            {
                //set timer to 0
                StopTimer();
            }

            //update visual display
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
	}

    //starts timer
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    //stop timer
    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }
    //is timer running
    public bool IsTimerRunning()
    {
        if (timeRemaining !=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    }
