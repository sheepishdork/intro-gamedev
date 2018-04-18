using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour {

	public Text itemText;
	public Text detailsText;
	public GameObject ItemDetails;

	Rigidbody2D rbody;

	void Start() {
		rbody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	public void ViewItem(Details details) {
		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = false;
		rbody.constraints = RigidbodyConstraints2D.FreezePosition;

		itemText.text = details.itemName;

		detailsText.text = details.itemDetails;
	}

	public void CloseViewItem() {
		ItemDetails.SetActive (false);

		PlayerMovement moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement> ();
		moveScript.canMove = false;
		rbody.constraints = RigidbodyConstraints2D.FreezePosition;
	}
}