using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBarController : MonoBehaviour {

	public GameObject[] progressBarTiles;
	public GameObject numberOfLevel;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 25; i++) {
			if (i < PlayerPrefs.GetInt ("selectedLevel")) {
				progressBarTiles [i].SetActive (true);
			} else {
				progressBarTiles [i].SetActive (false);
			}
		}

		numberOfLevel.GetComponent<Text> ().text = PlayerPrefs.GetInt ("selectedLevel").ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
