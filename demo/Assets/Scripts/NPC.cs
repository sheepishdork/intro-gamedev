using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	public Dialogue dialogue;
	public GameObject DialogueBox;

	public void TriggerDialogue () {
		DialogueBox.SetActive (true);
		FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
	}

	public void ContinueDialogue () {
		FindObjectOfType<DialogueManager> ().DisplayNextSentence ();
	}
}