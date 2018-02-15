using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMove : MonoBehaviour {

	private Vector3 startPos;
	private Vector3 destinationPos;
	private Vector3 nextPos;

	public float speed;

	public Transform destination;

	void Start () {
		startPos = transform.localPosition;
		destinationPos = destination.localPosition;
		nextPos = destinationPos;
	}

	void Update () {
		Move ();
	}

	void Move () {
		transform.localPosition = Vector3.MoveTowards (transform.localPosition, nextPos, (speed * Time.deltaTime));
		if (Vector3.Distance (transform.localPosition, nextPos) <= 0.1)
			ChangeDestination ();
	}

	void ChangeDestination () {
		nextPos = nextPos != startPos ? startPos : destinationPos;
	}
}
