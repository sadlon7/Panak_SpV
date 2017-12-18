using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonController : MonoBehaviour {
	public GameObject gameController;
	public GameObject sequenceHolder;
	public GameObject playerGO;
	public GameObject commandIconPrefab;
	public string command;

	public void addToStack() {

		// OBMEDZENIE POCTU KROKOV
		if(gameController.GetComponent<PlayController>().movesCount <= sequenceHolder.transform.childCount){
			return;
		}
		GameObject temp = Instantiate(commandIconPrefab);
		temp.GetComponent<CommandSequenceController>().commandValue =  command;
		temp.GetComponent<CommandSequenceController>().commandText.text =  command.ToUpper();
		temp.transform.SetParent(sequenceHolder.transform);
		
	}
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
