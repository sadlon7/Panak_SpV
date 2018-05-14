using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditLevel : MonoBehaviour {

	public GameObject plocha;
	public string [] plochaArr;

	public GameObject wallSprite;
	public GameObject doorSprite;
	public GameObject floorSprite;
	public GameObject backgroundSprite;
	public GameObject num;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("editing") == 1) {

			int lvl = PlayerPrefs.GetInt ("selectedOwnLevel");
			string text = PlayerPrefs.GetString ("mylevel" + lvl.ToString ()).ToString ();
			string [] lines = text.Split ('\n');

			Debug.Log ("POCET POLICOK" + lines[0]);

			num.GetComponent<Text> ().text = lines[0];

			for (int i = 1; i < lines.Length - 1; i++) {
				this.plochaArr [i - 1] = lines [i];
			}

			for (int i = 0; i < plocha.transform.childCount; i++) {
				for (int j = 0; j < plocha.transform.GetChild (i).childCount; j++) {

					plocha.transform.GetChild (i).transform.GetChild (j).GetComponent<PlayGridTileController> ().tileType = plochaArr [i] [j].ToString ();

					switch (plochaArr [i] [j].ToString ()) {

					case "X":
						plocha.transform.GetChild (i).transform.GetChild (j).GetComponent<Image> ().sprite = wallSprite.GetComponent<Image> ().sprite;
						//background.color = new Color(255f,0f,0f);
						break;
					case "o":
						plocha.transform.GetChild (i).transform.GetChild (j).GetComponent<Image> ().sprite = doorSprite.GetComponent<Image> ().sprite;
						//background.color = new Color(0f,255f,0f);
						break;
					case "_":
						plocha.transform.GetChild (i).transform.GetChild (j).GetComponent<Image> ().sprite = floorSprite.GetComponent<Image> ().sprite;
						//background.color = new Color(0f,0f,205f);
						break;
					case " ":
						plocha.transform.GetChild (i).transform.GetChild (j).GetComponent<Image> ().sprite = backgroundSprite.GetComponent<Image> ().sprite;
						//background.color = new Color (255f, 255f, 255f);
						break;
					case "d":
						break;
					}
				}
			}


		}
	}
}
