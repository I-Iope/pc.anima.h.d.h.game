using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {

	public float speed;
	public float yPosition;
	public int levelAdvancement;

	private bool triggered;
	private Vector3 destination;

	void Start () {
		destination = new Vector3 (transform.localPosition.x,  yPosition, transform.localPosition.z);
	}

	void Update () {
		if ((triggered || PlayerPrefs.GetInt("LevelAdvancement") >= levelAdvancement) && Vector3.Distance (transform.localPosition, destination) >= 0.1) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, destination, (speed * Time.deltaTime));
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player")
		triggered = true;
	}
}
