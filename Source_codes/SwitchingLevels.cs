using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwitchingLevels : MonoBehaviour {

	public GameObject prevButton;
	public GameObject nextButton;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("selectedLevel") <= 1) {
			prevButton.GetComponent<Button> ().interactable = false;
		} else {
			prevButton.GetComponent<Button> ().interactable = true;
		}

		if (PlayerPrefs.GetInt ("selectedLevel") >= 25 || PlayerPrefs.GetInt("selectedLevel") >= PlayerPrefs.GetInt("maxLevel")) {
			nextButton.GetComponent<Button> ().interactable = false;
		} else {
			nextButton.GetComponent<Button> ().interactable = true;
		}

	}

	public void GoToPrevScene(){
		int selectedLevel = PlayerPrefs.GetInt ("selectedLevel");
		if (selectedLevel > 1) {
			PlayerPrefs.SetInt("selectedLevel",--selectedLevel);
			SceneManager.LoadScene ("Hra");
		}
	}

	public void GoToNextScene(){
		int selectedLevel = PlayerPrefs.GetInt ("selectedLevel");
		if (selectedLevel < 25 && PlayerPrefs.GetInt("maxLevel") > selectedLevel) {
			PlayerPrefs.SetInt("selectedLevel",++selectedLevel);
			SceneManager.LoadScene ("Hra");
		}
	}

	public void MakeNextButtonVisible(){
		nextButton.GetComponent<Button> ().interactable = true;
	}
}
