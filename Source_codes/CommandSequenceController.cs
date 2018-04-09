using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandSequenceController : MonoBehaviour {
	public Text commandText;
	public string commandValue;

	public Sprite leftButton;
	public Sprite rightButton;
	public Sprite upButton;
	public Sprite downButton;

	public Sprite [] repeatStart;
	public Sprite repeatEnd;


	// Pridava tlacidla do dolnej listy
	void Start () {

		if (commandText.text.Equals ("L")) {
			this.GetComponent<Image>().sprite = leftButton;
//			this.GetComponent<Image>().color = new Color32(128,255,55,100);
		}
		else if(commandText.text.Equals ("R")){
			this.GetComponent<Image>().sprite = rightButton;
		}
		else if(commandText.text.Equals ("U")){
			this.GetComponent<Image>().sprite = upButton;
		}
		else if(commandText.text.Equals ("D")){
			this.GetComponent<Image>().sprite = downButton;
		}

		else if(commandText.text.Equals ("E")){
			this.GetComponent<Image>().sprite = repeatEnd;
		}

		else //if(commandText.text.Equals ("2"))
		{
			
			this.GetComponent<Image>().sprite = repeatStart[int.Parse(commandText.text)-2];
		}
	}

	public void destroy() {
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
