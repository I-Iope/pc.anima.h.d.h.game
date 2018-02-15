using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnColliderPlatform : MonoBehaviour {

	public float waitTime;
	public float gravityScale;

	private Rigidbody2D rb2D;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		rb2D.isKinematic = true;
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.tag == "Player") {
			StartCoroutine (FallPlatform ());
		}
	}

	IEnumerator FallPlatform () {
		yield return new WaitForSeconds (waitTime);
		rb2D.isKinematic = false;
		rb2D.gravityScale = gravityScale;
	}
}
