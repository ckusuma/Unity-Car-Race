using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject carPrefab1;
    public GameObject carPrefab2;

    GameObject player1;
    GameObject player2;

    public int numBalloonsPerPlayer;
    public int player1Lives;
    public int player2Lives;

    Transform spawn1;
    Transform spawn2;

    
    
	// Use this for initialization
	void Start () {
        //instantiate the players
        spawn1 = GameObject.FindGameObjectWithTag("spawn1").transform;
        spawn2 = GameObject.FindGameObjectWithTag("spawn2").transform;

        player1 = Instantiate(carPrefab1, spawn1.position, Quaternion.Euler(spawn1.transform.rotation.eulerAngles));
        player2 = Instantiate(carPrefab2, spawn2.position, Quaternion.Euler(spawn2.transform.rotation.eulerAngles));

        player1Lives = numBalloonsPerPlayer;
        player2Lives = numBalloonsPerPlayer;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
