using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpustiButtonController : MonoBehaviour {
	public GameObject gameController;
	public GameObject playerController;
	public GameObject sequenceGameobject;

	public string commandFromSequence;

	public GameObject WrongInput;

	public void run() {

		//Debug.Log(PlayerPrefs.GetString("levelik"));

		WrongInput.SetActive (false);



		playerController.GetComponent<PlayerController>().setPosition();
		commandFromSequence = "";
		
		for(int i=0; i<sequenceGameobject.transform.childCount;i++){

			commandFromSequence+=sequenceGameobject.transform.GetChild(i).GetComponent<CommandSequenceController>().commandValue;
		}
	
		// sem pojde algoritmus









		gameController.GetComponent<PlayController>().commands = commandFromSequence;

		if (!gameController.GetComponent<PlayController> ().play ()) {
			WrongInput.SetActive (true);
		}



		//Debug.Log ("Vykonavana sekvencia = " + commandFromSequence);

	}
	// Use this for initialization
	void Start () {
		commandFromSequence = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
