using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGridController : MonoBehaviour {
	public float width;
	public float height;

	// Use this for initialization
	void Start () {
		this.width = this.GetComponent<RectTransform>().rect.width;
		this.height = this.GetComponent<RectTransform>().rect.height;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
