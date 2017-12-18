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


	// Use this for initialization
	void Start () {

		if (commandText.text.Equals ("L")) {
			this.GetComponent<Image>().sprite = leftButton;
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
	}

	public void destroy() {
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
