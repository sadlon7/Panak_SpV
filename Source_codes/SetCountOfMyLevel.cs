using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SetCountOfMyLevel : MonoBehaviour {

	public GameObject num;

	public void Increment(){

		int value = Convert.ToInt32(num.GetComponent<Text> ().text);
		value++;
		if (value > 32) {
			value = 1;
		}
		if (value < 1) {
			value = 32;
		}

		num.GetComponent<Text> ().text = value.ToString ();
		
	}

	public void Decrement(){

		int value = Convert.ToInt32(num.GetComponent<Text> ().text);
		value--;
		if (value > 32) {
			value = 1;
		}
		if (value < 1) {
			value = 32;
		}

		num.GetComponent<Text> ().text = value.ToString ();
	}
}
