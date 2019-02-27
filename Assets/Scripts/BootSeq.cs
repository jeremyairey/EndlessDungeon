using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootSeq : MonoBehaviour
{

    public GameObject[] BootSequence;
    public int DelayTime;

    void Start()
    {

    

        //0 = Title Screen
        //1 = Create Character
        //2 = GamePlay

            BootSequence[0].SetActive(true);   // Show title screen
            BootSequence[1].SetActive(false); // Hide Create a Character
            BootSequence[2].SetActive(false); // Hide gameplay screens
        Debug.Log("starting sleep");

        Invoke("ShowCharacterSelect", DelayTime);

      

    }

 
    IEnumerator WaitForIt(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }

    
    void ShowCharacterSelect()
    {
        Debug.Log("finished sleeping");

        BootSequence[1].SetActive(true);  //show character screen
        BootSequence[0].SetActive(false); // hide title screen
    }






}
