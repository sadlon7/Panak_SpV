using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayController : MonoBehaviour {

	public Sprite floorSprite;
	public Sprite wallSprite;
	public Sprite doorSprite;
	public Sprite backgroundSprite;

	public GameObject plocha;

	public string[] plochaArr;
	public int movesCount;

	public string commands;
	public GameObject player;

	public void play(){
		StartCoroutine(player.GetComponent<PlayerController> ().go (commands));
	}

	public void readFile(string lvl)
	{
		//string path = "Levely/level"+lvl+".txt";
		//StreamReader reader = new StreamReader(path);

		TextAsset textWrap = (TextAsset)Resources.Load("Levely/level"+lvl,typeof(TextAsset));

		//Debug.Log ("TOTO JE CESTA: " + textWrap);

		string text = textWrap.ToString();

		string[] lines = text.Split ('\n');
		this.movesCount = int.Parse(lines[0]);

		for(int i=1;i<lines.Length-1;i++){
			this.plochaArr [i-1] = lines [i];
		}
		//reader.Close();
	}
	public void loadLevel(int level) {
		readFile (level.ToString());
		for (int i = 0; i < plocha.transform.childCount; i++) {
			for (int j = 0; j < plocha.transform.GetChild(i).childCount; j++) {
				plocha.transform.GetChild(i).transform.GetChild(j).GetComponent<PlayGridTileController> ().tileType = plochaArr [i][j].ToString();
				plocha.transform.GetChild(i).transform.GetChild(j).GetComponent<PlayGridTileController> ().init();
					
			}
		}

	} 
	// Use this for initialization
	void Start () {
		this.movesCount = movesCount;
		this.plochaArr = plochaArr;

		// AKY LEVEL
		int lvl = PlayerPrefs.GetInt("selectedLevel");
		loadLevel(lvl);
		
		this.play();
		//PlayerPrefs.SetInt("maxLevel",25);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
