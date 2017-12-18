using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpustiButtonController : MonoBehaviour {
	public GameObject gameController;
	public GameObject playerController;
	public GameObject sequenceGameobject;

	public string commandFromSequence;

	public void run() {
		playerController.GetComponent<PlayerController>().setPosition();
		commandFromSequence = "";
		
		for(int i=0; i<sequenceGameobject.transform.childCount;i++){

			commandFromSequence+=sequenceGameobject.transform.GetChild(i).GetComponent<CommandSequenceController>().commandValue;
		}
		gameController.GetComponent<PlayController>().commands = commandFromSequence;
		gameController.GetComponent<PlayController>().play();

	}
	// Use this for initialization
	void Start () {
		commandFromSequence = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
