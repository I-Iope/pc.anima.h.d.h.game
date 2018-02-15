using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour {

	public Transform player;

	void Update () {
		transform.position = new Vector3 (player.position.x, transform.position.y, transform.position.z);
	}
}
