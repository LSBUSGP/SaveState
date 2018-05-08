using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameState
{
	public List<string> inventory = new List<string> ();
}

public class Inventory : MonoBehaviour {

	public Text inventoryItem;

	public void Add (string itemName)
	{
		Text item = Instantiate (inventoryItem, transform);
		item.text = itemName;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.S)) {

			Save ();
		}

		if (Input.GetKeyDown (KeyCode.L)) {

			Load ();
		}
	}

	string SaveFilePath()
	{
		string path = Application.persistentDataPath;
		string name = "SaveFile.txt";
		return Path.Combine (path, name);
	}

	public void Save()
	{
		SaveGameState state = new SaveGameState ();
		foreach (Text child in transform.GetComponentsInChildren<Text>()) {
			state.inventory.Add(child.text);
		}

		using (StreamWriter file = File.CreateText (SaveFilePath()))
		{
			file.WriteLine (JsonUtility.ToJson (state));
		}
	}

	public void Load()
	{
		using (StreamReader file = File.OpenText (SaveFilePath()))
		{
			Dictionary<string, Pickup> pickupItems = new Dictionary<string, Pickup> ();
			foreach (var pickup in FindObjectsOfType<Pickup>()) {
				pickupItems.Add (pickup.name, pickup);
			}

			string saveString = file.ReadLine ();
			var state = JsonUtility.FromJson<SaveGameState> (saveString);
			foreach (var item in state.inventory) {
				Add(item);
				Pickup pickup;
				if (pickupItems.TryGetValue (item, out pickup)) {
					pickup.gameObject.SetActive (false);
				}
			}
		}
	}
}
