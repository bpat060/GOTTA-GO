using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Controller : MonoBehaviour
{
    public static float map_speed = -2f;
    public static float bg_speed = 0.2f;
    private float timeCounter = 0;
    private static float accelerateCounter = 0;
    

    //MAX SPEED
    const float MAX_MAP_SPEED = -4f;
    
    //Rush Speed
    const float map_rush_speed = -6f;
    const float bg_rush_speed = 0.6f;

    

    //System speed (Player Current Speed)
    float map_system_speed = -2f;
    float bg_system_speed = 0.2f;


    const float accelerate_radio = 1.3f;
    

    private void FixedUpdate() 
    {
        //Player's speed increase according to Time
        timeCounter += Time.deltaTime;
        if(accelerateCounter > 0)
        {
            accelerateCounter -= Time.deltaTime;
        }

        //Player's speed return to current speed when Rush Minipower time up
        if(accelerateCounter <= 0)
        {
            map_speed = map_system_speed;
            bg_speed = bg_system_speed;
            PlayerController.hasShield = false;
        }

        if(timeCounter >= 1 && Mathf.Abs(map_speed) < Mathf.Abs(MAX_MAP_SPEED))
        {
            
            map_system_speed *= accelerate_radio;
            bg_system_speed *= accelerate_radio;
            timeCounter = 0;
        }

        
    }

    public static void Accelerate()
    {
        //when player get minipower, increase the current speed to Rush speed 
        //and status change to "hasShield", not gonna be destroied when touch obstacles
        accelerateCounter = 5;
        map_speed = map_rush_speed;
        bg_speed = bg_rush_speed;

        PlayerController.hasShield = true;

        
    }

}
