using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownUpControll : MonoBehaviour {

	public int advancement;
	public float downPosition;
	public float speed;

	private Vector3 startPos;
	private Vector3 nextPos;
	private Vector3 destinationPos;

	void Start () {
		startPos = transform.localPosition;
		destinationPos = transform.localPosition;
		destinationPos.y = downPosition; 
		nextPos = destinationPos;
	}

	void Update () {
		if (advancement <= PlayerPrefs.GetInt ("LevelAdvancement")) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, nextPos, (speed * Time.deltaTime));

			if (Vector3.Distance (transform.localPosition, nextPos) <= 0)
				nextPos = nextPos != destinationPos ? destinationPos : startPos;
		}
	}
}
