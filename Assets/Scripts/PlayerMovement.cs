using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidBody;
	[SerializeField]
	private RandomSoundPlayer toadStep;
	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}
	void FixedUpdate () {
		if (movement != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
			Quaternion newRotation = Quaternion.Lerp (playerRigidBody.rotation, targetRotation, turningSpeed * Time.deltaTime);
			playerRigidBody.MoveRotation(newRotation);
			playerAnimator.SetFloat ("Speed", 3f);
			toadStep.enabled = true;
		} else {
			playerAnimator.SetFloat ("Speed", 0f);
			toadStep.enabled = false;
		}
	}
}
