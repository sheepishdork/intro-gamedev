using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	public AudioClip SoundEffect;
	public AudioSource MusicSource;

	void Start() {
		MusicSource.clip = SoundEffect;
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadetoBlack ());

		MusicSource.Play ();
		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine (sf.FadetoClear ());
	}
}
