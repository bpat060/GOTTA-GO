using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    //variables for the manager
    public Transform spawner;
    private Vector2 spawnerStartPoint;

    public PlayerController thePlayer;
    private Vector2 playerStartPoint;

    private MapController[] spawnerList;

    // Start is called before the first frame update
    void Start()
    {
        //sets start spawn for the player
        playerStartPoint = spawner.position;
        playerStartPoint = thePlayer.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //method for restarting game when dead.
    public void RestartGame()
    {
        SceneManager.LoadScene(2);
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
