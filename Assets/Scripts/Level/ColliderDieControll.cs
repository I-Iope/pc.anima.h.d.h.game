using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderDieControll : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player")
			SceneManager.LoadScene (PlayerPrefs.GetInt ("Level"), LoadSceneMode.Single);
	}

}
