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

	public void incrementLoop(){

		GameObject ForStart = GameObject.Find ("Canvas/PanelPrikazov/ForStart");
		int c = int.Parse (ForStart.GetComponent<CommandButtonController> ().command);

		if (c == 9){
			return;
		}
	
		ForStart.GetComponent<Image> ().sprite = commandIconPrefab.GetComponent<CommandSequenceController> ().repeatStart [c-1];
		ForStart.GetComponent<CommandButtonController> ().command = (c+1).ToString();
	
	}

	public void decrementLoop(){

		GameObject ForStart = GameObject.Find ("Canvas/PanelPrikazov/ForStart");
		int c = int.Parse (ForStart.GetComponent<CommandButtonController> ().command);

		if (c == 2){
			return;
		}

		ForStart.GetComponent<Image> ().sprite = commandIconPrefab.GetComponent<CommandSequenceController> ().repeatStart [c-3];
		ForStart.GetComponent<CommandButtonController> ().command = (c-1).ToString();

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
