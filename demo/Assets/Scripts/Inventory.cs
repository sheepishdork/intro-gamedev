using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory = new GameObject[9];
	public Button[] inventoryButtons = new Button[9];

	public void AddItem(GameObject item) {

		bool itemAdded = false;

		for (int i = 0; i < inventory.Length; i++) {
			if (inventory [i] == null) {
				inventory [i] = item;
				inventoryButtons [i].image.overrideSprite = item.GetComponent<SpriteRenderer> ().sprite;
				Debug.Log (item.name + " was added to inventory.");
				break;
			}
		}
	}
}
