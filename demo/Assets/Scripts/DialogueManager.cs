using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public GameObject DialogueBox;

	Rigidbody2D rbody;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		rbody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	public void StartDialogue(Dialogue dialogue) {

		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = false;
		rbody.constraints = RigidbodyConstraints2D.FreezePosition;

		nameText.text = dialogue.name;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
			DisplayNextSentence ();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

		void EndDialogue() {
		DialogueBox.SetActive (false);

		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = true;
		rbody.constraints = RigidbodyConstraints2D.None;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
