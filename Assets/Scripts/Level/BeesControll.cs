using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesControll : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player") {
			FollowPlayer.follow = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Player") { 
			FollowPlayer.follow = false;
		}
	}
}
