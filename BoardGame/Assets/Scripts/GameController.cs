using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    List<GameObject> players;
    bool isRunning = true;

	// Use this for initialization
	void Start () {
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(players);
	    
	}
}
