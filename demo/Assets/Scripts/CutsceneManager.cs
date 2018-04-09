using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour {

	public int sceneIndex;
	public Text nameText;
	public Text dialogueText;
	public GameObject DialogueBox;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue) {

		nameText.text = dialogue.name;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			StartCoroutine (EndDialogue ());
			return;
		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	IEnumerator EndDialogue() {
		
		DialogueBox.SetActive (false);

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadetoBlack ());

		SceneManager.LoadScene (sceneIndex);

		yield return StartCoroutine (sf.FadetoClear ());
	}
}
