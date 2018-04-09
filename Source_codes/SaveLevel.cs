using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLevel : MonoBehaviour {

	private string level = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Save() {
		level = "20\n";
			
		GameObject plocha = GameObject.Find ("Canvas/Plocha");

		int riadky = plocha.transform.childCount;

		for (int i = 0; i < riadky; i++) {

			GameObject go = plocha.transform.GetChild(i).gameObject;
			int stlpce = go.transform.childCount;
//			
			for (int j = 0; j < stlpce; j++){
				string nazovPolicka = go.transform.GetChild (j).GetComponent<Image> ().sprite.name;

				if (nazovPolicka.Equals ("floor")) {
					level += "_";
				}
				else if (nazovPolicka.Equals ("block")) {
					level += "X";
				}
				else if (nazovPolicka.Equals ("whiteBlock")) {
					level += " ";
				}
				else if (nazovPolicka.Equals ("door")) {
					level += "o";
				}
			}
			level += '\n';
		}
		int indexOfLast = PlayerPrefs.GetInt ("indexOfLastLevel");
		string nameOfLevel = "mylevel" + indexOfLast;
		PlayerPrefs.SetString (nameOfLevel, level);

//		PlayerPrefs.SetInt ("indexOfLastLevel", indexOfLast + 1);


		//		sekvenciaPrikazov.transform.GetChild(indexOfActual[i-1]).GetComponent<Image>().color = new Color32(255,255,255,255);	
	}
}
