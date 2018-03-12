using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int posX;
	public int posY;
	public int defPosX;
	public int defPosY;
	public GameObject gamecontroller;
	public bool coroutineRunning;

	public GameObject nextButton;
	public GameObject GameOver;

	// Use this for initialization

	public bool canMove(int x,int y) {
		return gamecontroller.GetComponent<PlayController>().plocha.transform.GetChild(y).transform.GetChild(x).GetComponent<PlayGridTileController> ().isPassable();
	}


	public bool canDrop2(int x,int y) {
		return gamecontroller.GetComponent<PlayController>().plocha.transform.GetChild(y).transform.GetChild(x).GetComponent<PlayGridTileController> ().canDrop();
	}


	public void setPosition(int x=1, int y=6) {
		posX=x;
		posY=y;

		this.transform.SetParent(gamecontroller.GetComponent<PlayController> ().plocha.transform.GetChild (y).transform.GetChild (x).transform) ;
		this.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
	}

	public IEnumerator move(string d, int i) {

//		Debug.Log ("d = " + d);

//		Debug.Log ("TU SOM str = " + d);
		
		coroutineRunning = true;
		switch (d) {
		case "u":
			if (canMove (posX, posY - 1)) {
				posY -= 1;
			}
			break;
		case "l":	
			if (canMove (posX - 1, posY)) {
				posX -= 1;
			}
			break;
		case "r":
			if (canMove (posX + 1, posY)) {
				posX += 1;
			}
			break;

		case "d":
			if (canMove (posX, posY + 1)) {
				posY += 1;
			}
			break;

		}

		while (canDrop2 (posX, posY) && canMove (posX, posY + 1)) {
			this.transform.SetParent (gamecontroller.GetComponent<PlayController> ().plocha.transform.GetChild (posY).transform.GetChild (posX).transform);
			this.GetComponent<RectTransform> ().localPosition = new Vector3 (0f, 0f, 0f);
			yield return new WaitForSeconds (.25f);
			Debug.Log ("Dostal som sa do canDrop2");
			posY += 1;
		}



		this.transform.SetParent (gamecontroller.GetComponent<PlayController> ().plocha.transform.GetChild (posY).transform.GetChild (posX).transform);
		this.GetComponent<RectTransform> ().localPosition = new Vector3 (0f, 0f, 0f);

		GameObject sekvenciaPrikazov = GameObject.Find ("Canvas/SekvenciaPrikazov");
		sekvenciaPrikazov.transform.GetChild(i).GetComponent<Image>().color = new Color32(240,130,40,255);

		if(i >= 1){    // Odfarbovanie predoslo zafarbenych tlacidiel
			sekvenciaPrikazov.transform.GetChild(i-1).GetComponent<Image>().color = new Color32(255,255,255,255);	
		}





		// PAUZA MEDZI SKOKMI
		yield return new WaitForSeconds(.4f);

		if (i == sekvenciaPrikazov.transform.childCount-1) {
			sekvenciaPrikazov.transform.GetChild(i).GetComponent<Image>().color = new Color32(255,255,255,255);
		}

		coroutineRunning = false;

	}
	
	public IEnumerator go(string sequence) {

		yield return new WaitForSeconds(.1f);
		for(int i=0; i<sequence.Length; i++) {
			StartCoroutine(move(sequence[i].ToString(), i));
			while(coroutineRunning) {
				yield return new WaitForSeconds(.1f);
			}
		}
		// FINISH
		if(this.transform.parent.GetComponent<PlayGridTileController>().tileType == "o") {
			Debug.Log("finish");
			GameOver.SetActive (true);
			int maxLevel = PlayerPrefs.GetInt("maxLevel");
			int selectedLevel = PlayerPrefs.GetInt("selectedLevel");

			if (maxLevel == selectedLevel && selectedLevel <= 25) {
				maxLevel++;
				PlayerPrefs.SetInt("maxLevel", maxLevel);
				nextButton.GetComponent<Button> ().interactable = true;
			}
		}
	}	

	void Start () {
		defPosY=6;
		defPosX=1;

		posY=6;
		posX=1;

		GameOver.SetActive (false);
		
		this.transform.SetParent(gamecontroller.GetComponent<PlayController> ().plocha.transform.GetChild (posY).transform.GetChild (posX).transform);
		this.GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
