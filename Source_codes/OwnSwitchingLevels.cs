using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OwnSwitchingLevels : MonoBehaviour {

	public GameObject prevButton;
	public GameObject nextButton;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("selectedOwnLevel") <= 1) {
			prevButton.GetComponent<Button> ().interactable = false;
		} else {
			prevButton.GetComponent<Button> ().interactable = true;
		}

		if (PlayerPrefs.GetInt ("selectedOwnLevel") >= 25 || PlayerPrefs.GetInt("selectedOwnLevel") >= PlayerPrefs.GetInt("indexOfLastLevel")) {
			nextButton.GetComponent<Button> ().interactable = false;
		} else {
			nextButton.GetComponent<Button> ().interactable = true;
		}

	}

	public void OwnGoToPrevScene(){
		int selectedLevel = PlayerPrefs.GetInt ("selectedOwnLevel");
		if (selectedLevel > 1) {
			PlayerPrefs.SetInt("selectedOwnLevel",--selectedLevel);
			SceneManager.LoadScene ("HrajMojuHru");
		}
	}

	public void OnwGoToNextScene(){
		int selectedLevel = PlayerPrefs.GetInt ("selectedOwnLevel");
		if (selectedLevel < 25 && PlayerPrefs.GetInt("indexOfLastLevel") > selectedLevel) {
			PlayerPrefs.SetInt("selectedOwnLevel",++selectedLevel);
			SceneManager.LoadScene ("HrajMojuHru");
		}
	}

	public void MakeNextButtonVisible(){
		nextButton.GetComponent<Button> ().interactable = true;
	}
}
