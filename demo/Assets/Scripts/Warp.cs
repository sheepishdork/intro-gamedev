using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	public AudioClip SoundEffect;
	public AudioSource MusicSource;

	Rigidbody2D rbody;

	void Start() {
		MusicSource.clip = SoundEffect;
		rbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D> ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		
		//stops player movement
		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = false;
		rbody.constraints = RigidbodyConstraints2D.FreezePosition;

		//causes screen fade
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
	
		yield return StartCoroutine (sf.FadetoBlack ());

		MusicSource.Play ();

		//moves player and camera position to warp target
		other.gameObject.transform.position = warpTarget.position;
		Camera.main.transform.position = warpTarget.position;

		yield return StartCoroutine (sf.FadetoClear ());

		//player can move again
		moveScript.canMove = true;
		rbody.constraints = RigidbodyConstraints2D.None;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

	}
}
