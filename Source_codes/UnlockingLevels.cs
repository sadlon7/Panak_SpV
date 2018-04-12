using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockingLevels : MonoBehaviour {

	public GameObject[] lvl;


	// Use this for initialization
	void Start () {

		//PlayerPrefs.SetInt ("maxLevel", 12);

		int maxLevel = PlayerPrefs.GetInt ("maxLevel");
		if (maxLevel == 0) {
			maxLevel = 1;
			PlayerPrefs.SetInt ("maxLevel", 1);
		}

		for (int i = 0; i < maxLevel; i++) {
			lvl [i].GetComponent<Button> ().interactable = true;
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
