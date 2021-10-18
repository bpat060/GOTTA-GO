using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GameManager1 : MonoBehaviour
{
    //variables for the manager
    public Transform spawner;
    private Vector2 spawnerStartPoint;

    //public PlayFabManager playFabManager;
    //[SerializeField] private PlayFabManager playfabManager;
    //private readonly PlayFabManager playfabManager = new PlayFabManager();

    public PlayerController thePlayer;
    private Vector2 playerStartPoint;

    private MapController[] spawnerList;

    // Start is called before the first frame update
    void Start()
    {
        //playfabManager.Login();
        //sets start spawn for the player
        playerStartPoint = spawner.position;
        playerStartPoint = thePlayer.transform.position;
        
    }

    /*private void Awake()
    {
        // Try and get the component if it is attached to the same object as this
        if (!playfabManager) playfabManager = GetComponent<PlayFabManager>();

        // Or try and find it anywhere in the scene
        if (!playfabManager) playfabManager = FindObjectOfType<PlayFabManager>();

        // Or simply create and attach it to the same object as this one
        if (!playfabManager) playfabManager = gameObject.AddComponent<PlayFabManager>();
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    //method for restarting game when dead.
    public void RestartGame()
    {
        SceneManager.LoadScene(2);
        //Save score
        //playFabManager.SendLeaderboard(PlayerController.totalScore);
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        //make player object invisible and resets it.
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //deletes the obstacles and every variable in spawner class when dead...only the scrolling background it visible.
        spawnerList = FindObjectsOfType<MapController>();
        for(int i=0; 1 < spawnerList.Length; i++)
        {
            spawnerList[i].gameObject.SetActive(false);
        }
        //player and spawner reset and return to the start position
        thePlayer.transform.position = playerStartPoint;
        spawner.position = spawnerStartPoint;
        thePlayer.gameObject.SetActive(true);
        //need to add the code to reset the camera movement.
    }
}
