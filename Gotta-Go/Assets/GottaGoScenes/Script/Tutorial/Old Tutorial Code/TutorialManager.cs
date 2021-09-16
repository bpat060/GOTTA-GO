using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialManager : MonoBehaviour
{


    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawn;
    public float waitTime = 2f;
    
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);            
            }
        }

        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                popUpIndex++;
            }
        } 
        else if (popUpIndex == 2)
        {
            if(waitTime <= 0)
            {
                spawn.SetActive(true);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

   
}
