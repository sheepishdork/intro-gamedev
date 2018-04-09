﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneNPC : MonoBehaviour {
	
	public Dialogue dialogue;
	public GameObject DialogueBox;

	public void TriggerDialogue () {
		DialogueBox.SetActive (true);
		FindObjectOfType<CutsceneManager> ().StartDialogue (dialogue);
	}

	public void ContinueDialogue () {
		FindObjectOfType<CutsceneManager> ().DisplayNextSentence ();
	}
}