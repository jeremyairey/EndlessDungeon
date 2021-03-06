﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootSeq : MonoBehaviour
{

    public GameObject[] BootSequence;
    public int DelayTime;

    void Awake()
    {

        BootSequence[0].SetActive(true);   // Show title screen
        BootSequence[1].SetActive(false); // Hide Create a Character
        BootSequence[2].SetActive(false); // Hide gameplay screens


    }

    void Start()
    {

    

        //0 = Title Screen
        //1 = Create Character
        //2 = GamePlay

            //BootSequence[0].SetActive(true);   // Show title screen
            //BootSequence[1].SetActive(false); // Hide Create a Character
            //BootSequence[2].SetActive(false); // Hide gameplay screens
        
        Invoke("ShowCharacterSelect", DelayTime);
            }

 
    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }

    
    void ShowCharacterSelect()
    {
        BootSequence[1].SetActive(true);  //show character screen
        BootSequence[0].SetActive(false); // hide title screen

        Invoke("ShowGameField", DelayTime);

    }


    void ShowGameField()
    {
        BootSequence[2].SetActive(true); // Show gameplay screen
        BootSequence[1].SetActive(false);  //Hide character select screen
               


     }




}
