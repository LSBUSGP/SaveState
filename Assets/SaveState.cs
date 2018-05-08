using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : MonoBehaviour {

	public int score = 0;

	void Start () {
		Debug.Log (score);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			score += 100;
			Debug.Log (score);
		}

		if (Input.GetKeyDown (KeyCode.S)) {

			PlayerPrefs.SetInt ("Game Score", score);
		}

		if (Input.GetKeyDown (KeyCode.L)) {

			score = PlayerPrefs.GetInt ("Game Score");
			Debug.Log (score);
		}
	}
}
