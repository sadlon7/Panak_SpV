using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateGameController : MonoBehaviour {

	public Sprite floorSprite;
	public Sprite wallSprite;
	public Sprite doorSprite;
	public Sprite backgroundSprite;

	public GameObject plocha;

	public string[] plochaArr;
	public int movesCount;

	public string commands;
	public string finalCommands = "";
	public List<int> indexOfActual;
	public GameObject player;


	public void loadLevel(int level) {

		for (int i = 0; i < plocha.transform.childCount; i++) {
			for (int j = 0; j < plocha.transform.GetChild(i).childCount; j++) {
				plocha.transform.GetChild(i).transform.GetChild(j).GetComponent<PlayGridTileController> ().tileType = plochaArr [i][j].ToString();
				plocha.transform.GetChild(i).transform.GetChild(j).GetComponent<PlayGridTileController> ().init();
					
			}
		}

	} 



	// Use this for initialization
	void Start () {
//		this.plochaArr = plochaArr;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
