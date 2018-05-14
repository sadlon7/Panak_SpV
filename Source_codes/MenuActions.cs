using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuActions : MonoBehaviour {

	public void GoToScene(string sceneName){
		PlayerPrefs.SetInt ("editing", 0);
		SceneManager.LoadScene (sceneName);
	}

	public void GoToScene2 (string sceneName)
	{
		PlayerPrefs.SetInt ("editing", 1);
		SceneManager.LoadScene (sceneName);
	}

	public void GoToSceneEditing ()
	{
		if (PlayerPrefs.GetInt ("editing") == 1) {
			SceneManager.LoadScene ("VlastnyLevelMenu");
		} else{
			SceneManager.LoadScene ("MainMenu");
		}

		PlayerPrefs.SetInt ("editing", 0);

	}

	public void SetSelectedLevel(int lvl){
		PlayerPrefs.SetInt("selectedLevel",lvl);
		//Debug.Log (PlayerPrefs.GetInt ("selectedLevel").ToString ());
	}

	public void SetSelectedOwnLevel(int lvl){
		PlayerPrefs.SetInt("selectedOwnLevel", lvl);
		//Debug.Log (PlayerPrefs.GetInt ("selectedOwnLevel").ToString ());
	}

	public void ResetProgress(){
		PlayerPrefs.SetInt("maxLevel",1);
	}

	public void CheatUnlock(){
		PlayerPrefs.SetInt("maxLevel",25);
	}

	public void CheatOwnLock(){
		PlayerPrefs.SetInt("indexOfLastLevel",0);
	}

	public void QuitGame(){
		//Debug.Log ("Skoncil som appku");
		Application.Quit();
	}


}

