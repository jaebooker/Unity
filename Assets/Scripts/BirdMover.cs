using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BirdMover : MonoBehaviour {
	[SerializeField]
	private Transform target;
	private NavMeshAgent birdAgent;
	private Animator birdAnimator;
	[SerializeField]
	private RandomSoundPlayer birdStep;
	void Start () {
		birdAgent = GetComponent<NavMeshAgent> ();
		birdAnimator = GetComponent<Animator> ();
	}
	void Update () {
		birdAgent.SetDestination (target.position);
		float speed = birdAgent.velocity.magnitude;
		birdAnimator.SetFloat ("Speed", speed);
		if (speed == 0f) {
			birdStep.enabled = false;
		} else {
			birdStep.enabled = true;
		}
	}
}
