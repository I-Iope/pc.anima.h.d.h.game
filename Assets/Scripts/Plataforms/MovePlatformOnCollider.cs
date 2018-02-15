using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformOnCollider : MonoBehaviour {

	private bool move;

	private Vector3 startPos;
	private Vector3 destinationPos;
	private Vector3 nextPos;

	public float speed;

	public Transform destnation;

	void Start () {
		move = false;
		startPos = transform.localPosition;
		destinationPos = destnation.localPosition;
		nextPos = destinationPos;
	}
	

	void Update () {
		if (move) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, nextPos, (Time.deltaTime * speed));
		}

		if (Vector3.Distance (transform.localPosition, nextPos) <= 0.1) {
			nextPos = nextPos != startPos ? startPos : destinationPos;
			move = false;
		}
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.tag == "Player")
			move = true;
			collider.transform.SetParent (transform);
	}

	void OnCollisionExit2D (Collision2D collider) {
		if (collider.gameObject.tag  == "Player")
			move = false;
			collider.transform.SetParent (null);
	}
}
