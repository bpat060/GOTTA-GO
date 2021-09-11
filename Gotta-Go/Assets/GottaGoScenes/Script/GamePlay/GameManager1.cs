using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Transform spawner;
    private Vector2 spawnerStartPoint;

    public PlayerController thePlayer;
    private Vector2 playerStartPoint;

    private MapController[] spawnerList;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPoint = spawner.position;
        playerStartPoint = thePlayer.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        spawnerList = FindObjectsOfType<MapController>();
        for(int i=0; 1 < spawnerList.Length; i++)
        {
            spawnerList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        spawner.position = spawnerStartPoint;
        thePlayer.gameObject.SetActive(true);
    }
}
