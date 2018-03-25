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
	public string finalCommands = "";
	public List<int> indexOfActual;
	public GameObject player;





	public bool play(){
		
		if (!isRightCommand ()) {
			
			return false;
		}
		finalCommands = "";
		indexOfActual = new List<int> ();
		createSequence (commands, 0);

		StartCoroutine(player.GetComponent<PlayerController> ().go (finalCommands, indexOfActual));

		return true;
	}



	public bool isRightCommand(){
		Stack stack = new Stack ();
		for (int i = 0; i < commands.Length; i++) {
			if ((int)commands [i] >= 50 && (int)commands [i] <= 57) {
				stack.Push (commands [i]);
			}
			if (commands [i] == 'e') {
				if (stack.Count == 0){
					Debug.Log ("Nemam co vytiahnut, zly sting");
					return false;
				}
				stack.Pop ();
			}
		}

		if (stack.Count != 0) {
			Debug.Log ("Neprazdny zasobnik, zly sting");
			return false;
		}
		Debug.Log ("string OK");
		return true;
	}

	public void createSequence(string ret, int ix) {

		for(int i=0; i<ret.Length; i++) {
			
			if (ret [i] == 'r' || ret [i] == 'l' || ret [i] == 'u' || ret [i] == 'd') {
				finalCommands += ret [i];

				indexOfActual.Add (ix);
				ix += 1;


			} else if ((int)ret [i] >= 50 && (int)ret [i] <= 57) {
				string pom = "";
				int c = i + 1;
				int poc = 0;

				while (ret [c] != 'e' || poc != 0) {
					//					Debug.Log ("Dostal som sa do WHILE + " + (int)ret[c]);

					if ((int)ret [c] >= 50 && (int)ret [c] <= 57) {
						poc++;
					} else if (ret [c] == 'e') {
						poc--;
					}

					//					Debug.Log ("retC = " + ret[c]);

					pom += ret [c];
					c++;
				}

				//				Debug.Log (" XX " + pom.ToString());

				//				Debug.Log (" >>> " + pom);
				//				Debug.Log (" >>> cislo =  " + (int.Parse (ret [i].ToString()) - 1).ToString());

				ix += 1;
				for (int j = 0; j < int.Parse (ret [i].ToString ()) - 1; j++) {
					//Debug.Log ("ix = " + ix);
					createSequence (pom, ix);

				}


			} else {
				ix += 1;
			}



		}
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
