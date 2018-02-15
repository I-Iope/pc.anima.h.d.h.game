using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollider : MonoBehaviour {

	public GameObject dropPrefab;
	public Transform transformPosition;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player") {
			Instantiate (dropPrefab, transformPosition.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
