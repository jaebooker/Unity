using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {
	private AudioSource audioSource;
	[SerializeField]
	private List<AudioClip> soundClips = new List<AudioClip>();
	[SerializeField]
	private float soundTimerDelay = 3f;
	private float soundTimer;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	void Update () {
		soundTimer = soundTimer + Time.deltaTime;
		if (soundTimer >= soundTimerDelay) {
			soundTimer = 0f;
			AudioClip randomSound = soundClips[Random.Range(0, soundClips.Count)];
			audioSource.PlayOneShot (randomSound);
		}
	}
}
