using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour {
	public static int score;
	private Text scoreCounterText;
	// Use this for initialization
	void Start () {
		score = 0;
		scoreCounterText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (score == 1) {
			scoreCounterText.text = score + " Fly";
		} else {
			scoreCounterText.text = score + " Flies";
		}
	}
}
