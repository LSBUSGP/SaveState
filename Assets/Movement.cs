using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	float speed = 50.0f;

	void Update () {

		float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float y = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		transform.Translate (x, 0.0f, y);
	}
}
