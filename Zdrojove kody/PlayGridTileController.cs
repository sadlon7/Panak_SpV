using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGridTileController : MonoBehaviour {
	public string tileType;
	public GameObject gamecontroller;
	

	// Use this for initialization
	public bool isPassable() {
		// PO COM SA DA CHODIT
		//if (tileType == "_" || tileType == "o" || tileType == "-" || tileType == "-")
		if (tileType == "X"){
			return false;
		}
		return true;
	}

	public bool canDrop(){
		if(tileType == " "){
			return true;
		}
		return false;
	}

	public void init (){
		gamecontroller = GameObject.Find("GameController");	
		Image background = this.GetComponent<Image>();

		switch(this.tileType) {
		/*case "a":
			background.color = new Color (0f, 0f, 255f);
			break;*/
		case "X":
			this.GetComponent<Image>().sprite = gamecontroller.GetComponent<PlayController>().wallSprite;
			//background.color = new Color(255f,0f,0f);
			break;
		case "o":
			this.GetComponent<Image>().sprite = gamecontroller.GetComponent<PlayController>().doorSprite;
			//background.color = new Color(0f,255f,0f);
			break;
		case "_":
			this.GetComponent<Image>().sprite = gamecontroller.GetComponent<PlayController>().floorSprite;
			//background.color = new Color(0f,0f,205f);
			break;
		case " ":
			this.GetComponent<Image>().sprite = gamecontroller.GetComponent<PlayController>().backgroundSprite;
			//background.color = new Color (255f, 255f, 255f);
			break;
		case "d":
			break;
		}
		background.preserveAspect = true;
	}



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
