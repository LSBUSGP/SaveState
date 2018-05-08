using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public Inventory inventory;

	void OnTriggerEnter (Collider collider) {
		gameObject.SetActive (false);
		inventory.Add (gameObject.name);
	}


}
