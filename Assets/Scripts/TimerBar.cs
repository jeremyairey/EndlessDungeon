using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    public Image FillBar;
    public Image EmptyBar;
    public Image HourGlass;
    
    public float refreshRate;  //How often we poll the timer to update the bar
    public int totalPifs = 18;
    public float degreesPerSecond;

    public float maxTimerSeconds = 60;  //60 seconds = 0.3 per pif = 17 pifs and 1 no pif.  for 18
    public float maxFill = 1.0f;   //Maximum state is what we want it set.  We then decrease it
    public float currentFill;

    public float currentTimerSeconds{ get; private set; }

    //********************************
    //********************************
    private void OnEnable()
    {
        currentTimerSeconds = maxTimerSeconds; // we always start with 60 seconds.
        currentFill = maxFill; // always set to full pif
     }

    //********************************
    //********************************
    private void SetTimer(float seconds)
    {
        currentTimerSeconds = seconds;                
     }
    
 
    void UpdateTimers()
    {
        currentTimerSeconds -= refreshRate;
        currentFill = currentTimerSeconds / maxTimerSeconds;
        
        if(currentTimerSeconds<=0.0)
        {

            Debug.Log("Game Action Reset");
            currentTimerSeconds = maxTimerSeconds;
            
        }

        FillBar.fillAmount = (1.0f - currentFill);
     }


    //********************************
    //********************************
    private void Start()
    {
        StartCoroutine("TimerCountdown");
        StartCoroutine("SpinHourGlass");
    }

    //********************************
    //********************************
    IEnumerator TimerCountdown()
    {

        while (true)
        {
            yield return new WaitForSeconds(refreshRate);
             UpdateTimers(); 

        }
    }

    

    void Update()
    {

      //  HourGlass.transform.Rotate(Vector3.forward * Time.deltaTime * degreesPerSecond);
    }



    IEnumerator SpinHourGlass()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            float timer = 0f;
            Quaternion lastRotation = HourGlass.transform.rotation; //transform.rotation;
            while (timer < 1)
            {

                HourGlass.transform.Rotate(0, 0, -180 * Time.deltaTime);
                //transform.rotate(0, 0, 180 * Time.deltaTime);
                timer = timer + Time.deltaTime;
                yield return null;
            }

            HourGlass.transform.rotation = lastRotation;
            //transform.rotation = lastRotation;
            HourGlass.transform.Rotate(0, 0, -180);
         }
    }




}
