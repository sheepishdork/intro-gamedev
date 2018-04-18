using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour {

	public AudioClip SoundEffect;
	public AudioSource MusicSource;

	Rigidbody2D rbody;

	void Start() {
		MusicSource.clip = SoundEffect;
		rbody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	public int sceneIndex;
	public bool npc;
	public bool interactable;
	public bool item;


	IEnumerator GoToClass() {

		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = false;
		rbody.constraints = RigidbodyConstraints2D.FreezePosition;

		MusicSource.Play ();

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadetoBlack ());

		SceneManager.LoadScene (sceneIndex);

		yield return StartCoroutine (sf.FadetoClear ());

		moveScript.canMove = true;
		rbody.constraints = RigidbodyConstraints2D.None;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}
}