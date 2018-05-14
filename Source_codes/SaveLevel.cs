using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveLevel : MonoBehaviour {

	private string level = "";
	public GameObject SavedPopUpWindow;
	public GameObject MaxPopUpWindow;
	public GameObject Count;

	// Use this for initialization
	void Start () {
		SavedPopUpWindow.SetActive (false);
		MaxPopUpWindow.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save() {

		if (PlayerPrefs.GetInt ("editing") == 0) {

			int indexOfLast = PlayerPrefs.GetInt ("indexOfLastLevel");

			if (indexOfLast >= 25) {
				MaxPopUpWindow.SetActive (true);
				return;
			}

			SavedPopUpWindow.GetComponentInChildren<Text> ().GetComponent<Text> ().text = "ULOŽIL SI ÚLOHU " + (indexOfLast + 1);
			SavedPopUpWindow.SetActive (true);

			saveLevel ();

			indexOfLast++;
			PlayerPrefs.SetInt ("indexOfLastLevel", indexOfLast);

			string nameOfLevel = "mylevel" + indexOfLast;
			PlayerPrefs.SetString (nameOfLevel, level);
		} else{

			SavedPopUpWindow.GetComponentInChildren<Text> ().GetComponent<Text> ().text = "ULOŽIL SI ÚLOHU " + (PlayerPrefs.GetInt("selectedOwnLevel"));
			SavedPopUpWindow.SetActive (true);

			saveLevel ();

			string nameOfLevel = "mylevel" + PlayerPrefs.GetInt ("selectedOwnLevel");
			PlayerPrefs.SetString (nameOfLevel, level);
		}

	}

	private void saveLevel(){
		level = Count.GetComponent<Text> ().text + "\n";

		GameObject plocha = GameObject.Find ("Canvas/Plocha");

		int riadky = plocha.transform.childCount;

		for (int i = 0; i < riadky; i++) {

			GameObject go = plocha.transform.GetChild (i).gameObject;
			int stlpce = go.transform.childCount;
			//			
			for (int j = 0; j < stlpce; j++) {
				string nazovPolicka = go.transform.GetChild (j).GetComponent<Image> ().sprite.name;

				if (nazovPolicka.Equals ("floor")) {
					level += "_";
				} else if (nazovPolicka.Equals ("block")) {
					level += "X";
				} else if (nazovPolicka.Equals ("whiteBlock")) {
					level += " ";
				} else if (nazovPolicka.Equals ("door")) {
					level += "o";
				}
			}
			level += '\n';
		}
	}
}
