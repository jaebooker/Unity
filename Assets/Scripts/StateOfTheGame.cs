using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateOfTheGame : MonoBehaviour {
	private bool gameStarted = false;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BirdMover birdMover;
	[SerializeField]
	private FollowCamera followCamera;
	private float restartDelay = 3f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;
	void Start () {
		Cursor.visible = false;
		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerMovement.enabled = false;
		birdMover.enabled = false;
		followCamera.enabled = false;
	}

	void Update () {
		if (!gameStarted && (Input.GetKeyUp (KeyCode.Space))) {
			StartGame();
		}
		if (!playerHealth.alive) {
			EndGame();
			restartTimer = restartTimer + Time.deltaTime;
			if (restartTimer >= restartDelay) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	private void StartGame () {
		gameStarted = true;
		gameStateText.color = Color.clear;
		playerMovement.enabled = true;
		birdMover.enabled = true;
		followCamera.enabled = true;

	}
	private void EndGame () {
		gameStarted = false;
		gameStateText.color = Color.blue;
		gameStateText.text = "You died, my darling.";
		player.SetActive (false);
	}
}
