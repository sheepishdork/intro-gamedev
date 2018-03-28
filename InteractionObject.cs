using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

	public AudioClip SoundEffect;
	public AudioSource MusicSource;

	void Start() {
		MusicSource.clip = SoundEffect;
	}

	public bool npc;
	public bool interactable;
	public bool inventory;

	public void DoInteraction() {
		gameObject.SetActive (false);
	}

	IEnumerator GoToClass() {
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadetoBlack ());

		MusicSource.Play ();

		yield return StartCoroutine (sf.FadetoClear ());
	}
}
