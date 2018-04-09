using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelectedTile : MonoBehaviour {

	public void SetIndex(int index){
		PlayerPrefs.SetInt ("SelectedTileOfCreatingLevel", index);
	}

}
