using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBG : MonoBehaviour
{
    Material material;
    public Vector2 speed;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //to increase/control the background animation speed, linked with Speed_Controller
        movement += new Vector2(Speed_Controller.bg_speed,0) * Time.deltaTime;
        material.mainTextureOffset = movement;
    }
}
