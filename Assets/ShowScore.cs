using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	public Text score;
	public SaveState state;

	void Update () {
		score.text = state.score.ToString();	
	}
}
