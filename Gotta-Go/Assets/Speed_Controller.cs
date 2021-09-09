using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Controller : MonoBehaviour
{
    public static float map_speed = -2f;
    public static float bg_speed = 1;
    private float timeCounter = 0;
    private static float accelerateCounter = 0;
    private static bool isAcc = false;

    //MAX SPEED
    const float MAX_MAP_SPEED = -4;
    const float accelerate_radio = 1.1f;
    
    
    private void FixedUpdate() 
    {
        timeCounter += 0.02f;
        if(accelerateCounter > 0)
        {
            accelerateCounter -= Time.deltaTime;
        }

        if(accelerateCounter <= 0 && isAcc)
        {
            map_speed /= 2;
            bg_speed /= 2;
            accelerateCounter = 0;
            isAcc = false;
            PlayerController.hasShield = false;
        }

        if(timeCounter >= 1 && Mathf.Abs(map_speed) < Mathf.Abs(MAX_MAP_SPEED))
        {
            
            map_speed *= accelerate_radio;
            bg_speed *= accelerate_radio;
            timeCounter = 0;
        }
    }

    public static void Accelerate()
    {
        accelerateCounter = 5;
        isAcc = true;
        map_speed *= 2;
        bg_speed *= 2;

        PlayerController.hasShield = true;
    }

}
