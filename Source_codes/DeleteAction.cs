using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


public class DeleteAction : MonoBehaviour {

	public GameObject PopUpWindow;
	//public GameObject PopUpButtonDelete;
	//public GameObject PopUpButtonExit;



	Stopwatch sw = new Stopwatch();
	private bool isPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isPressed) {
			if (sw.ElapsedMilliseconds / 1000.0 > 1.0) {
				// OTVORIM OKNO S VYMAZANIM
				PopUpWindow.SetActive(true);
				isPressed = false;
			}
		}
	}

	public void OnDown(int lvl){
		if (IsInteractable (lvl)) {
			PlayerPrefs.SetInt ("selectedOwnLevel", lvl);
			sw.Start ();
			isPressed = true;
		}
		//UnityEngine.Debug.Log ("Spustil");
	}

	public bool IsInteractable(int lvl){
		GameObject button = GameObject.Find ("Canvas/Plocha/Riadok (" + ((lvl-1)/5) + ")/L" + lvl);
		//UnityEngine.Debug.Log ("Canvas/Plocha/Riadok (" + ((lvl - 1) / 5) + ")/L" + lvl);
		return button.GetComponent<Button> ().interactable;

	}

	public void OnUp(int lvl){ 
		if (IsInteractable (lvl)) {
			if (sw.ElapsedMilliseconds / 1000.0 < 1.0) {
				SceneManager.LoadScene ("HrajMojuHru");
			}

			isPressed = false;
			sw.Stop ();

			sw.Reset ();
		}
		//UnityEngine.Debug.Log ("Skoncil");
		
	}

	public void ClosePopUp(){
		PopUpWindow.SetActive (false);
	}

	public void DeleteLevel(){
		int lastIndex = PlayerPrefs.GetInt ("indexOfLastLevel");
		int selectedLevel = PlayerPrefs.GetInt ("selectedOwnLevel");
		string levelName = "mylevel" + PlayerPrefs.GetInt ("selectedOwnLevel");
		for (int i = selectedLevel; i < lastIndex; i++) {
			string levelString = PlayerPrefs.GetString("mylevel" + (i+1));
			PlayerPrefs.SetString ("mylevel" + i, levelString);
		}

		PlayerPrefs.SetInt("indexOfLastLevel", lastIndex - 1);
			
			

		PopUpWindow.SetActive (false);
		SceneManager.LoadScene ("VlastnyLevelMenu");

	}
		
}
