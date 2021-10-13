using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Play Through all menu scenes
    private static MenuAudioStart instance = null;
    public static MenuAudioStart Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {
        
    }
}
