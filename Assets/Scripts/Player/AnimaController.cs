using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaController : MonoBehaviour {

	public Transform player;
	public float speed;

	void Start() {
		transform.position = player.position;
	}

	void Update () {
		transform.localPosition = Vector3.MoveTowards (transform.position, player.position, (speed * Time.deltaTime)); 
		if (Vector3.Distance (transform.position, player.position) > 30) {
			transform.position = player.position;
		}
	}
}
