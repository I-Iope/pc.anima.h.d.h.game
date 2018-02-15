using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseAnimation : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = gameObject.GetComponent<Animator> ();
		anim.speed = 0;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player") {
			anim.speed = 1;
		}
	}

}
