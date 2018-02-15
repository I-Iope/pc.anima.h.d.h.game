using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour {

	public static bool follow;

	public Transform playerTransform;
	public float speed;

	void Start () {
		follow = false;
	}

	void Update () {
		if (follow) {
			transform.position = Vector3.MoveTowards (transform.position, playerTransform.position, (speed * Time.deltaTime));
		}

		if (Vector3.Distance (transform.position, playerTransform.position) <= 0.5f) {
			SceneManager.LoadScene (PlayerPrefs.GetInt ("Level"), LoadSceneMode.Single);
		}
	}
}
