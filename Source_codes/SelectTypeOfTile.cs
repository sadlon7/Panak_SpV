using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class SelectTypeOfTile : MonoBehaviour {

	//public GameObject element;
	public GameObject stena;
	public GameObject trava;
	public GameObject dvere;
	public GameObject nic;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("SelectedTileOfCreatingLevel", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTile(){
		GameObject go = EventSystem.current.currentSelectedGameObject;

		int selected = PlayerPrefs.GetInt ("SelectedTileOfCreatingLevel");

		if (selected == 0) {
			go.GetComponent<Image> ().sprite = stena.GetComponent<Image> ().sprite;
			//Debug.Log (go.GetComponent<Image> ().sprite.name.ToString ());
		}
		else if (selected == 1) {
			go.GetComponent<Image> ().sprite = trava.GetComponent<Image> ().sprite;
			//Debug.Log (go.GetComponent<Image> ().sprite.name.ToString ());
		}
		else if (selected == 2) {
			go.GetComponent<Image> ().sprite = dvere.GetComponent<Image> ().sprite;
		}
		else if (selected == 3) {
			go.GetComponent<Image> ().sprite = nic.GetComponent<Image> ().sprite;
		}
	}
}
