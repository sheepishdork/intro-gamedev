using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	public GameObject currentInterObj = null;
	public InteractionObject currentInterObjScript = null;
	public Inventory inventory;

	void Update() {
		if (Input.GetButtonDown ("Interact") && currentInterObj) {
			if (currentInterObjScript.npc) {
				currentInterObj.SendMessage ("TriggerDialogue");
			}
			if (currentInterObjScript.interactable) {
				currentInterObj.SendMessage ("GoToClass");
			}
			if (currentInterObjScript.inventory) {
				inventory.AddItem (currentInterObj);
				currentInterObj.SendMessage ("PickUp");
			}
		}
		if (Input.GetButtonDown ("Continue") && currentInterObj) {
			if (currentInterObjScript.npc) {
				currentInterObj.SendMessage ("ContinueDialogue");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("interObject")) {
			currentInterObj = other.gameObject;
			currentInterObjScript = currentInterObj.GetComponent<InteractionObject> ();
			Color tmp = currentInterObj.GetComponent<Renderer> ().material.color;
			tmp.a = 0.75f;
			currentInterObj.GetComponent<Renderer> ().material.color = tmp;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag ("interObject")) {
			if(other.gameObject == currentInterObj) {
				Color tmp = currentInterObj.GetComponent<Renderer> ().material.color;
				tmp.a = 1f;
				currentInterObj.GetComponent<Renderer>().material.color = tmp;
				currentInterObj = null;
			}
		}
	}
}
