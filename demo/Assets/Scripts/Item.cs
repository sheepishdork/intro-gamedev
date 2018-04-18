using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public Details details;
	public GameObject ItemDetails;

	public void TriggerClue() {
		ItemDetails.SetActive (true);
		FindObjectOfType<ItemsManager> ().ViewItem (details);
		Destroy(gameObject);
	}
}
