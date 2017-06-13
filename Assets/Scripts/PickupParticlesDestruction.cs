using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupParticlesDestruction : MonoBehaviour {
	void Start () {
		// destroy the particles after 5 seconds
		Destroy(gameObject, 5f);
	}
}
