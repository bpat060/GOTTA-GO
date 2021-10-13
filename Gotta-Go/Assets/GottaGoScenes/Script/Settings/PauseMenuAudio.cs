using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MenuAudioStart.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
